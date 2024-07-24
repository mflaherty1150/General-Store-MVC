using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Models.ProductModels;

public class ProductEdit
{
    [Required]
    public int Id { get; set; }

    [Required, MinLength(3), MaxLength(200)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "QuantityInStock must be greater than or equal to 0")]
    public int QuantityInStock { get; set; }

    [Required]
    public double Price { get; set; }
}
