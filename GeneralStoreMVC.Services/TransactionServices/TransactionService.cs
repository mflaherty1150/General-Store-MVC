using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using GeneralStoreMVC.Data;
using GeneralStoreMVC.Data.Entities;
using GeneralStoreMVC.Models.Responses;
using GeneralStoreMVC.Models.TransactionModels;
using GeneralStoreMVC.Services.CustomerServices;
using GeneralStoreMVC.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreMVC.Services.TransactionServices;

public class TransactionService : ITransactionService
{
    private readonly GeneralStoreDbContext _dbContext;
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;
    public TransactionService(GeneralStoreDbContext dbContext,
                            IMapper mapper,
                            IProductService productService,
                            ICustomerService customerService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _customerService = customerService;
        _productService = productService;
    }

    public async Task<object> CreateNewTransactionAsync(TransactionCreate request)
    {
        var product = await _dbContext.Products.FindAsync(request.ProductId);
        if (product == null || product.QuantityInStock <= 0)
        {
            TextResponse response = new TextResponse("Product not found or Quantity is not sufficient.");
            return response;
        }

        if (request.Quantity <= 0 || request.Quantity > product.QuantityInStock)
        {
            TextResponse response = new TextResponse($"Not enough product instock. Only {product.QuantityInStock} units available.");
            return response;
        }

        var entry = _dbContext.Entry(product);

        // If it's not tracked, attach it
        if (entry.State == EntityState.Detached)
        {
            _dbContext.Products.Attach(product);
        }

        // var transactionEntity = _mapper.Map<TransactionCreate, TransactionEntity>(request);
        // _dbContext.Transactions.Add(transactionEntity);
        // await _dbContext.SaveChangesAsync();
        TransactionEntity transactionEntity;
        using (var transactionRequest = _dbContext.Database.BeginTransaction())
        {
            try
            {
                transactionEntity = new TransactionEntity()
                {
                    ProductId = request.ProductId,
                    CustomerId = request.CustomerId,
                    Quantity = request.Quantity,
                    DateOfTransaction = DateTime.Now
                };

                product.QuantityInStock -= request.Quantity;

                _dbContext.Transactions.Add(transactionEntity);

                await _dbContext.SaveChangesAsync();

                transactionRequest.Commit();
            }
            catch (Exception)
            {
                transactionRequest.Rollback();
                TextResponse response = new("TransactionCreation Failed");
                return response;
            }
        }

        var transactionReport = _dbContext.Transactions
            .Include(e => e.Customer)
            .Include(e => e.Product)
            .FirstOrDefault(e => e.Id == transactionEntity.Id);

        TransactionDetail newTransactionDetail = new TransactionDetail()
        {
            Id = transactionReport.Id,
            ProductId = transactionReport.ProductId,
            ProductName = transactionReport.Product.Name,
            CustomerId = transactionReport.CustomerId,
            CustomerName = transactionReport.Customer.Name,
            Quantity = transactionReport.Quantity,
            TransactionTotal = transactionReport.Quantity * transactionReport.Product.Price
        };

        return newTransactionDetail;
    }

    public async Task<bool> DeleteTransactionAsync(int id)
    {
        var transaction = await _dbContext.Transactions.FindAsync(id);

        if (transaction == null)
            return false;

        _dbContext.Transactions.Remove(transaction);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> EditTransactionInfoAsync(TransactionEdit request)
    {
        var transactionExists = await _dbContext.Transactions.AnyAsync(transaction =>
        transaction.Id == request.Id);

        if (!transactionExists)
            return false;

        var newEntity = _mapper.Map<TransactionEdit, TransactionEntity>(request);

        _dbContext.Entry(newEntity).State = EntityState.Modified;

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<List<TransactionIndex>> GetAllTransactionAsync()
    {
        var transactions = await _dbContext.Transactions
            .Select(entity => _mapper.Map<TransactionEntity, TransactionIndex>(entity))
            .ToListAsync();

        return transactions;
    }

    public async Task<TransactionDetail?> GetTransactionByIdAsync(int id)
    {
        var transactionEntity = await _dbContext.Transactions
            .Include(e => e.Product)
            .Include(e => e.Customer)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (transactionEntity is null)
        {
            return null;
        }
        double transactionTotal = transactionEntity.Quantity * transactionEntity.Product.Price;
        var transactionDetail = _mapper.Map<TransactionEntity, TransactionDetail>(transactionEntity);
        transactionDetail.TransactionTotal = transactionTotal;

        return transactionDetail;

    }

    public async Task<TransactionEdit?> GetTransactionByIdForEditAsync(int id)
    {
        var transactionEntity = await _dbContext.Transactions
            .FirstOrDefaultAsync(e => e.Id == id);

        return transactionEntity is null ? null : _mapper.Map<TransactionEntity, TransactionEdit>(transactionEntity);
    }

    public async Task<List<TransactionForCustomerDetail>> GetAllTransactionsForCustomerAsync(int customerId)
    {
        var transactions = await _dbContext.Transactions
            .Where(entity => entity.CustomerId == customerId)
            .Include(entity => entity.Product)
            .Include(entity => entity.Customer)
            .Select(entity => _mapper.Map<TransactionEntity, TransactionForCustomerDetail>(entity))
            .ToListAsync();

        double totalAmountSpent = transactions.Sum(transaction => transaction.TransactionTotal);

        var summary = new CustomerTransactionSummary
        {
            Transactions = transactions,
            TotalAmountSpent = totalAmountSpent
        };

        return summary;
        
    }

    private class CustomerTransactionSummary : List<TransactionForCustomerDetail>
    {
        public List<TransactionForCustomerDetail> Transactions { get; set; }
        public double TotalAmountSpent { get; set; }
    }
}
