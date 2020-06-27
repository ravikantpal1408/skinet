using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Ravi",
                    Email = "ravi@test.com",
                    UserName = "ravi@test.com",
                    Address = new Address
                    {
                        FirstName = "Ravi",
                        LastName = "Pal",
                        State = "Uttar Pradesh",
                        Street = "Faizabad Road",
                        City = "Lucknow",
                        Zipcode = "226016"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
            
            
            
        }
    }
}