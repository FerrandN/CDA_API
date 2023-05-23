﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiUser.Models
{
    [Table("Users")]
     public class User : Model
     {
        //[Column("user_name")]
        [Required(ErrorMessage = ("Le nom d'utilisateur est requis"))]
        //[MaxLength(16, ErrorMessage = "")]
        [StringLength(16, ErrorMessage = "")]
        [RegularExpression(@"^[a-zA-Z]+(?:\-[a-zA-Z]+)?$")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [RegularExpression(@"^[a-zA-Z0-9]{8,}$")]
        public string? Password { get; set; }

    }
}