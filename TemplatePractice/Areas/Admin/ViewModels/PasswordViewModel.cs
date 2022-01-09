using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Areas.Admin.ViewModels
{
    public class PasswordViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "You must include the old password"),DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage ="You must include a new password"), DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "You must confirm the password"),
            DataType(DataType.Password),Compare(nameof(NewPassword),
            ErrorMessage ="The passwords do not match!")]
        public string ConfirmedPassword { get; set; }
    }
}
