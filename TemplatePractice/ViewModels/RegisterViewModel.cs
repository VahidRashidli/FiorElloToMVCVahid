using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="This field is required")]
        public string FullName { get; set; }
        [Required,EmailAddress,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmedPassowrd { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
