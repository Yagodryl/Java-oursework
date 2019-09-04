using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavaAndReact.Entities
{
    public class SeederDB
    {
        public static void SeedUsers(UserManager<DbUser> userManager, RoleManager<DbRole> roleManager)
        {
            var count = roleManager.Roles.Count();
            if (count == 0)
            {
                var roleName = "Seller";
                var result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;

                roleName = "Client";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
            }
            count = userManager.Users.Count();
            if (count == 0)
            {
                var email = "seller@gmail.com";
                var roleName = "Seller";
                var user = new DbUser
                {
                    Email = email,
                    UserName = email

                };
                var result = userManager.CreateAsync(user, "Qwerty1-").Result;
                result = userManager.AddToRoleAsync(user, roleName).Result;
            }
           
        }
        public static void SeedProfiles(UserManager<DbUser> userManager, EFDbContext context)
        {
            var count = context.Sellers.Count();
            if (count == 0)
            {
                var seller1 = new SellerProfile
                {
                    FirstName = "Дмитро",
                    LastName = "Кізюк",
                    MiddleName = "Сергійович",
                    User = userManager.FindByEmailAsync("seller@gmail.com").Result,
                };
                context.Sellers.AddRange(new List<SellerProfile>
                {
                    seller1
                });
            }
            context.SaveChanges();
        }
        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
               // var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
                SeederDB.SeedUsers(manager, managerRole);
                SeederDB.SeedProfiles(manager, context);
            }

        }
    }
}
