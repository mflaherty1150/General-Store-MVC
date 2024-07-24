using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GeneralStoreMVC.Data.Entities;

public class TransactionEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "QuantityInStock must be greater than or equal to 0")]
    public int Quantity { get; set; }

    [Required]
    public DateTime DateOfTransaction { get; set; }

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public virtual CustomerEntity? Customer { get; set; } 

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public virtual ProductEntity Product { get; set; }
}
