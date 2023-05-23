using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions_Bancaires.Models
{
    abstract public class Model
    {
        [Key]
        public int transaction_id { get; set; }
    }
}
