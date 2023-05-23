using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankTransactions.Models
{
    public class BankTransaction
    {
        [Key]
        public int Transaction_Id { get; set; }

        [Required]
        public DateTime Transaction_Date { get; set; }

        [Required]
        [Range(10000000000, 99999999999)]
        public long Transaction_From { get; set; }

        [Required]
        [Range(10000000000, 99999999999)]
        public long Transaction_To { get; set; }

        [Required]
        [Range(0.01, 99000)]
        [Precision(7,2)]
        public decimal Transaction_Amount { get; set; }

        public bool UpdateFromAnotherTransactionInstance(BankTransaction transaction)
        {
            this.Transaction_Amount = Transaction_Amount;
            this.Transaction_From = Transaction_From;
            this.Transaction_To = Transaction_To;
            this.Transaction_Date = Transaction_Date;
            return true;
        }
    }
}