using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TemplatePractice.DAL
{
    public static class DbSeeder
    {
        public static async void Seed(this IApplicationBuilder builder)
        {
            using(IServiceScope scope = builder.ApplicationServices.CreateScope())
            {
                var dbcontext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var role = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                DataInitializer dataInitializer = new DataInitializer(dbcontext,role);
               await  dataInitializer.InitializeData();
            }
        }
    }
}
