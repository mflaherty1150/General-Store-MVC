using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeneralStoreMVC.Data;
using GeneralStoreMVC.Data.Entities;
using GeneralStoreMVC.Models.CustomerModels;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreMVC.Services.CustomerServices;

public class CustomerService : ICustomerService
{
    private readonly GeneralStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CustomerService(GeneralStoreDbContext dbContext, IMapper mapper)
    {   
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CustomerIndex?> CreateNewCustomerAsync(CustomerCreate request)
    {
        var customerEntity = _mapper.Map<CustomerCreate, CustomerEntity>(request);
        _dbContext.Customers.Add(customerEntity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        if(numberOfChanges == 1)
        {
            CustomerIndex response = _mapper.Map<CustomerEntity, CustomerIndex>(customerEntity);
            return response;
        }
        return null;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        
        if (customer == null)
            return false;

        _dbContext.Customers.Remove(customer);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> EditCustomerInfoAsync(CustomerEdit request)
    {
        var customerExists = await _dbContext.Customers.AnyAsync(customer => 
        customer.Id == request.Id);
        
        if(!customerExists)
            return false;
        
        var newEntity =_mapper.Map<CustomerEdit, CustomerEntity>(request);

        _dbContext.Entry(newEntity).State = EntityState.Modified;

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<List<CustomerIndex>> GetAllCustomersAsync()
    {
        var customers = await _dbContext.Customers
            .Select(entity => _mapper.Map<CustomerEntity, CustomerIndex>(entity))
            .ToListAsync();

            return customers; 
        // List<CustomerIndex> customers = await _dbContext.Customers
        //     .Select(r => new CustomerIndex()
        //     {
        //         Id = r.Id,
        //         Name = r.Name,
        //         Email = r.Email
        //     }).ToListAsync();

        // return customers;
    }

    public async Task<CustomerDetail?> GetCustomerByIdAsync(int id)
    {
        var customerEntity = await _dbContext.Customers
            .FirstOrDefaultAsync(e => e.Id == id);

        return customerEntity is null ? null : _mapper.Map<CustomerEntity, CustomerDetail>(customerEntity);
    }

    public async Task<CustomerEdit?> GetCustomerByIdForEditAsync(int id)
    {
        var customerEntity = await _dbContext.Customers
            .FirstOrDefaultAsync(e => e.Id == id);

        return customerEntity is null ? null : _mapper.Map<CustomerEntity, CustomerEdit>(customerEntity);
    }


}
