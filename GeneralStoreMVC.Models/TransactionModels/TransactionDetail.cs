using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreMVC.Models.TransactionModels
{
    public class TransactionDetail
    {
        [DisplayName("Transaction Number")]
        public int Id { get; set; }

        [DisplayName("Amount Purchased")]
        public int Quantity { get; set; }

        [DisplayName("Unique Customer Identifier")]
        public int CustomerId { get; set; }

        [DisplayName("Name of Customer")]
        public string? CustomerName { get; set; }

        [DisplayName("Unique Product Identifier")]
        public int ProductId { get; set; }

        [DisplayName("Product Purchased")]
        public string? ProductName { get; set; }

        [DisplayName("Date of Purchase")]
        public DateTime DateOfTransaction { get; set; }

        [DisplayName("Total Amount for Purchase in US Dollars:")]
        public double TransactionTotal { get; set; } 
    }
}