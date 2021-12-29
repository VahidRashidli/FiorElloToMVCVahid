using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.ViewModels
{
    public class AccountLoginViewModel
    {
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public bool KeepSignedIn { get; set; }
    }
}
