using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ToDoList.Entities.Concrete;

namespace ToDoList.WEB.Functions
{
    public static class IdentityInitilaizer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var memberUser = await userManager.FindByNameAsync("Dancho");
            if (memberUser == null)
            {
                var appuser = new AppUser
                {
                    UserName="Dancho",
                    Name = "Barış",
                    Surname = "Demirci",
                    Email = "barisdemirci9401@gmail.com"
                };
                await userManager.CreateAsync(appuser, "1");
                await userManager.AddToRoleAsync(appuser, "Member");
            }
        }
    }
}
