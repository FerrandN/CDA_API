using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUser.Models
{
    internal class UserUpdateViewModel : Model
    {
        //[Column("user_name")]
        [Required(ErrorMessage = ("Le nom d'utilisateur est requis"))]
        //[MaxLength(16, ErrorMessage = "")]
        [StringLength(maximumLength: 16, MinimumLength = 2, ErrorMessage = "")]
        [RegularExpression(@"^[a-zA-Z]+(?:\-[a-zA-Z]+)?$")]
        public string? UserName { get; set; }
    }
}
