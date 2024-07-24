using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Data.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(3), MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "QuantityInStock must be greater than or equal to 0")]
    public int QuantityInStock { get; set; }

    [Required]
    public double Price { get; set; }

    public virtual List<TransactionEntity>? Transactions { get; set; }
}
