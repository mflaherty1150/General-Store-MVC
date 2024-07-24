using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreMVC.Models.ProductModels;

namespace GeneralStoreMVC.Services.ProductServices;

public interface IProductService
{
    Task<ProductIndex?> CreateNewProductAsync(ProductCreate request);
    Task<List<ProductIndex>> GetAllProductAsync();
    Task<ProductDetail?> GetProductByIdAsync(int id);
    Task<bool> EditProductInfoAsync(ProductEdit request);
    Task<bool> DeleteProductAsync(int id);
    Task<ProductEdit?> GetProductByIdForEditAsync(int id);
}
