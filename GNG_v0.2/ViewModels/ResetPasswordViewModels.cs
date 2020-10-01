using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GNG_v0._2.ViewModels
{
    public class ResetPasswordViewModels
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password must be matched with Password")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
