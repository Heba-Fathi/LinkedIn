using Linkedin.DbContext;
using Linkedin.Models;
using Linkedin.Models.Entites;
using LinkedIn.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedIn.Core.Managers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
        //,Repository<ApplicationUser, ApplicationDbContext>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
           // manager.EmailService = new EmailService();
           // manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
        public List<ApplicationUser> GetAllConnections(string id)
        {
            ApplicationUser user = Users.FirstOrDefault(e => e.Id == id);
            List<ApplicationUser> ConnectionList = new List<ApplicationUser>();
            ConnectionList.AddRange(user.Connections);
            foreach (var item in Users.ToList())
            {
                if (item.Connections.Count!=0)
                {
                    if (item.Connections.FirstOrDefault(e => e.Id == id) != null)
                    {
                        ConnectionList.Add(item);
                    }
                }
            }
            return ConnectionList;
        }
        public List<ApplicationUser> GetRequestUsers(String id)
        {
            ApplicationUser user = Users.FirstOrDefault(e => e.Id == id);
            List<ApplicationUser> requestsList = new List<ApplicationUser>();
            foreach (var item in Users.ToList())
            {
                if (item.Requests.Count != 0)
                {
                    if (item.Requests.FirstOrDefault(e => e.Id == id) != null)
                    {
                        requestsList.Add(item);
                    }
                }
            }
            return requestsList;
        }
    }
}
