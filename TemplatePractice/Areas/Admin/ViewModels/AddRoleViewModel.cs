using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TemplatePractice.Areas.Admin.ViewModels
{
    public class AddRoleViewModel
    {
        public UserViewModel User { get; set; } = new UserViewModel();
        public ICollection<IdentityRole> Roles { get; set; }
        public string Role { get; set; }
    }
}
