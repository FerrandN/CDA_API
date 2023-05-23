using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transactions_Bancaires.Models
{
    [Table("BankTransaction")]
    public class BankTransaction : Model
    {
        [Required(ErrorMessage = ("Error DateTime required"))]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? transaction_date { get; set; }

        [Required(ErrorMessage = ("Error sender invalid"))]
        [StringLength(11, ErrorMessage = "11 characters required")]
        [RegularExpression(@"^[0-9]{11}$")]
        public string? transaction_from { get; set; }

        [Required(ErrorMessage = ("Error receiver invalid"))]
        [StringLength(11, ErrorMessage = "11 characters required")]
        [RegularExpression(@"^[0-9]{11}$")]
        public string? transaction_to { get; set; }

        [Required(ErrorMessage = ("Error transaction amount required"))]
        [RegularExpression(@"^[0-9]{1,5}(?:\.[0-9]{2})?$")]
        [Range(0,99000)]
        public float? transaction_amount { get; set; }
    }
}