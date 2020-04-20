using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using GUI_EX2_Buffet.Data;

namespace GUI_EX2_Buffet.Data
{
    public class DBHelper
    {

        public static void SeedData(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {
            SeedKitchen(userManager, log);
            SeedReception(userManager, log);
            SeedWaiter(userManager, log);
        }


        public static void SeedKitchen(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string KitchenEmail = "Kitchen@Kitchen.com";
            const string KitchenPassword = "Kitchen_1";

            if (userManager.FindByNameAsync(KitchenEmail).Result == null)
            {
                log.LogWarning("Seeding kitchen user");
                var user = new IdentityUser
                {
                    UserName = KitchenEmail,
                    Email = KitchenEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, KitchenPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("KitchenStaff", "Yes");
                    var adminClaimResult = userManager.AddClaimAsync(user, adminClaim);
                    adminClaimResult.Wait();
                }
            }
        }

        public static void SeedReception(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string ReceptionEmail = "Reception@Reception.dk";
            const string ReceptionPassword = "Reception_1";

            if (userManager.FindByNameAsync(ReceptionEmail).Result == null)
            {
                log.LogWarning("Seeding Reception user");
                var user = new IdentityUser
                {
                    UserName = ReceptionEmail,
                    Email = ReceptionEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, ReceptionPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("ReceptionStaff", "Yes");
                    var adminClaimResult = userManager.AddClaimAsync(user, adminClaim);
                    adminClaimResult.Wait();
                }
            }
        }

        public static void SeedWaiter(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string WaiterEmail = "Waiter@Waiter.dk";
            const string WaiterPassword = "Waiter_1";

            if (userManager.FindByNameAsync(WaiterEmail).Result == null)
            {
                log.LogWarning("Seeding waiter user");
                var user = new IdentityUser
                {
                    UserName = WaiterEmail,
                    Email = WaiterEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, WaiterPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("WaiterStaff", "Yes");
                    var adminClaimResult = userManager.AddClaimAsync(user, adminClaim);
                    adminClaimResult.Wait();
                }
            }
        }
    }
}