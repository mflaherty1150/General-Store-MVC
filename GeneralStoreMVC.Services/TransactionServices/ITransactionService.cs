using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreMVC.Models.TransactionModels;

namespace GeneralStoreMVC.Services.TransactionServices;

public interface ITransactionService
{
    Task<object> CreateNewTransactionAsync(TransactionCreate request);
    Task<List<TransactionIndex>> GetAllTransactionAsync();
    Task<TransactionDetail?> GetTransactionByIdAsync(int id);
    Task<bool> EditTransactionInfoAsync(TransactionEdit request);
    Task<bool> DeleteTransactionAsync(int id);
    Task<TransactionEdit?> GetTransactionByIdForEditAsync(int id);
    Task<List<TransactionForCustomerDetail>> GetAllTransactionsForCustomerAsync(int customerId);
}
