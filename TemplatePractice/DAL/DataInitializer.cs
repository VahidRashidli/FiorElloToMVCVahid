using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TemplatePractice.Areas.Admin.Constants;

namespace TemplatePractice.DAL
{
    public class DataInitializer
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _role;
        public DataInitializer(AppDbContext context, RoleManager<IdentityRole> role)
        {
            _context = context;
            _role = role;
        }

        public async Task InitializeData()
        {
            _context.Database.Migrate();
            if (!_context.Roles.Any())
            {
                await _role.CreateAsync(new IdentityRole(RoleConstants.Admin));
                await _role.CreateAsync(new IdentityRole(RoleConstants.Moderator));
                await _role.CreateAsync(new IdentityRole(RoleConstants.User));
            }
            await _context.SaveChangesAsync();
            
        }
    }
}
