using eFindingsRegister.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFindingsRegister.Logic.Abstract
{
    public interface IApplicationUserRepository: IDisposable
    {
        Task<ApplicationUser> CreateAsync(ApplicationUser user, CancellationToken cancellationToken);
        ApplicationUser Create(ApplicationUser user);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken);
        ApplicationUser Update(ApplicationUser user);
        ApplicationUser ActivateOrDeactivate(ApplicationUser user);
        Task<bool> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken);
        bool Delete(ApplicationUser user);
        Task<ApplicationUser> GetApplicationUserAsync(string applicationUserId);
        ApplicationUser GetApplicationUser(string applicationUserId);
        ApplicationUser GetApplicationUserByUserId(string UserId);
        Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync();
        IEnumerable<ApplicationUser> GetAllApplicationUsers();

        Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersBySupplierIdAsync(string SupplierId);
        User GetUserByUserId(string UserId);

        void Dispose();
    }
}
