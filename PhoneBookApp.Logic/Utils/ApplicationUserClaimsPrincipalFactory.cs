using eFindingsRegister.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;


namespace eFindingsRegister.Logic.Utils
{
    public class ApplicationUserClaimsPrincipalFactory :
      UserClaimsPrincipalFactory<User, Role>
    {

        public ApplicationUserClaimsPrincipalFactory(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var principal = await base.CreateAsync(user);

            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim(ClaimTypes.Uri, user.UserName)
            });

            System.Threading.Thread.CurrentPrincipal = principal;

            return principal;
        }
    }
}
