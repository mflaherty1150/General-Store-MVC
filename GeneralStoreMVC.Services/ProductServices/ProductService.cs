using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeneralStoreMVC.Data;
using GeneralStoreMVC.Data.Entities;
using GeneralStoreMVC.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreMVC.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly GeneralStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public ProductService(GeneralStoreDbContext dbContext,
                            IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<ProductIndex?> CreateNewProductAsync(ProductCreate request)
    {
        var productEntity = _mapper.Map<ProductCreate, ProductEntity>(request);
        _dbContext.Products.Add(productEntity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        if(numberOfChanges == 1)
        {
            ProductIndex response = _mapper.Map<ProductEntity, ProductIndex>(productEntity);
            return response;
        }
        return null;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        
        if (product == null)
            return false;

        _dbContext.Products.Remove(product);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> EditProductInfoAsync(ProductEdit request)
    {
        var productExists = await _dbContext.Products.AnyAsync(product => 
        product.Id == request.Id);
        
        if(!productExists)
            return false;
        
        var newEntity =_mapper.Map<ProductEdit, ProductEntity>(request);

        _dbContext.Entry(newEntity).State = EntityState.Modified;

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<List<ProductIndex>> GetAllProductAsync()
    {
        var products = await _dbContext.Products
            .Select(entity => _mapper.Map<ProductEntity, ProductIndex>(entity))
            .ToListAsync();

        return products;
    }

    public async Task<ProductDetail?> GetProductByIdAsync(int id)
    {
        var productEntity = await _dbContext.Products
            .FirstOrDefaultAsync(e => e.Id == id);

        return productEntity is null ? null : _mapper.Map<ProductEntity, ProductDetail>(productEntity);
    }

    public async Task<ProductEdit?> GetProductByIdForEditAsync(int id)
    {
        var productEntity = await _dbContext.Products
            .FirstOrDefaultAsync(e => e.Id == id);

        return productEntity is null ? null : _mapper.Map<ProductEntity, ProductEdit>(productEntity);
    }
}
