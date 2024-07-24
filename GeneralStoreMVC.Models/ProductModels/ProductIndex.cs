using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Models.ProductModels;

public class ProductIndex
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int QuantityInStock { get; set; }
    public double Price { get; set; }
}
