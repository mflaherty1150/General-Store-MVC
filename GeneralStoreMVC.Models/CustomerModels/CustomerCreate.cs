using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Models.CustomerModels;

public class CustomerCreate
{
    [Required]
    [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters long")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MinLength(1, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(150, ErrorMessage = "{0} must be no more than {1} characters long")]
    public string Email { get; set; } = string.Empty;
}
