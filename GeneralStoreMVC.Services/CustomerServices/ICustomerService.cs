using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreMVC.Models.CustomerModels;

namespace GeneralStoreMVC.Services.CustomerServices;

public interface ICustomerService
{
    Task<CustomerIndex?> CreateNewCustomerAsync(CustomerCreate request);
    Task<List<CustomerIndex>> GetAllCustomersAsync();
    Task<CustomerDetail?> GetCustomerByIdAsync(int id);
    Task<bool> EditCustomerInfoAsync(CustomerEdit request);
    Task<bool> DeleteCustomerAsync(int id);
    Task<CustomerEdit?> GetCustomerByIdForEditAsync(int id);
}
