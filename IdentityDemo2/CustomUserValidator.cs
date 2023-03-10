using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace IdentityDemo2
{
    public class CustomUserValidator<TUser> : UserValidator<TUser>, ICustomUserValidator<TUser>
    where TUser : IdentityUser
    {
        public override Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {

            if (!(user.UserName.Length >= 3))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "InvalidUsername",
                    Description = "Username should contain atleast 3 letters"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }

}
