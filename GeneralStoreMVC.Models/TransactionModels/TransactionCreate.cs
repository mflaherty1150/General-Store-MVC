using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Models.TransactionModels;

public class TransactionCreate
{
    [Required]
    public int Quantity { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int ProductId { get; set; }
}