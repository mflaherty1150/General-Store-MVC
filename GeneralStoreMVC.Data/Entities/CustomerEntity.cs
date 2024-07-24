using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(3), MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress, MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public virtual List<TransactionEntity>? Transactions { get; set; }
}
