using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       // [Required]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Microsoft.AspNetCore.Mvc.ModelBinding.BindNever]
        [ScaffoldColumn(false)]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
