using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using eFindingsRegister.Model.Entities;
using Microsoft.AspNetCore.Identity;

namespace eFindingsRegister.Logic.Utils
{
    public interface IUserStore
    {
        IQueryable<User> Users();

        #region IUserStore<ApplicationUser> implementation.

        Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken);

        Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken);

        Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken);

        Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);

        Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken);

        Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken);

        Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken);

        Task SetNormalizedUserNameAsync(User user, string normalizedName,
           CancellationToken cancellationToken);

        Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken);

        Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken);

        void Dispose();
        #endregion IUserStore<ApplicationUser> implementation.

        #region IUserEmailStore<ApplicationUser> implementation.

        Task SetEmailAsync(User user, string email, CancellationToken cancellationToken);

        Task<string> GetEmailAsync(User user, CancellationToken cancellationToken);

        Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken);

        Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken);

        Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken);

        Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken);

        Task SetNormalizedEmailAsync(User user, string normalizedEmail,
           CancellationToken cancellationToken);
        #endregion IUserEmailStore<ApplicationUser> implementation.

        #region IUserLoginStore<ApplicationUser> implementation.

        Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken);

        Task RemoveLoginAsync(User user, string loginProvider, string providerKey,
           CancellationToken cancellationToken);

        Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken);

        Task<User> FindByLoginAsync(string loginProvider, string providerKey,
           CancellationToken cancellationToken);
        #endregion IUserLoginStore<ApplicationUser> implementation.

        #region IUserPasswordStore<ApplicationUser> implementation.

        Task SetPasswordHashAsync(User user, string passwordHash,
           CancellationToken cancellationToken);

        Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken);

        Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken);
        #endregion IUserPasswordStore<ApplicationUser> implementation.

        #region IUserPhoneNumberStore<ApplicationUser> implementation.

        Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken);

        Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken);

        Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken);

        Task SetPhoneNumberConfirmedAsync(User user, bool confirmed,
           CancellationToken cancellationToken);

        #endregion IUserPhoneNumberStore<ApplicationUser> implementation.

        #region IUserTwoFactorStore<ApplicationUser> implementation.

        Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken);

        Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken);
        #endregion IUserTwoFactorStore<ApplicationUser> implementation.

        #region IUserSecurityStampStore<ApplicationUser> implementation.

        Task SetSecurityStampAsync(User user, string stamp, CancellationToken cancellationToken);

        Task<string> GetSecurityStampAsync(User user, CancellationToken cancellationToken);
        #endregion IUserSecurityStampStore<ApplicationUser> implementation.

        #region IUserClaimStore<ApplicationUser> implementation.

        Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken);

        Task AddClaimsAsync(User user, IEnumerable<Claim> claims,
           CancellationToken cancellationToken);

        Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim,
           CancellationToken cancellationToken);

        Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims,
           CancellationToken cancellationToken);

        Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken);
        #endregion IUserClaimStore<ApplicationUser> 

        #region IUserLockoutStore<ApplicationUser> implementation.

        Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken);

        Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd,
           CancellationToken cancellationToken);

        Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken);

        Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken);

        Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken);

        Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken);

        Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken);
        #endregion IUserLockoutStore<ApplicationUser> implementation.

        #region IUserRoleStore<ApplicationUser> implementation.

        Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken);

        Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken);

        Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken);

        Task<bool> IsInRoleAsync(User user, string roleName,
           CancellationToken cancellationToken);

        Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken);

        #endregion IUserRoleStore<ApplicationUser> implementation.
    }
}
