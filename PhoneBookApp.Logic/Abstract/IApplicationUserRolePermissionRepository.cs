using eFindingsRegister.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace eFindingsRegister.Logic.Abstract
{
    public interface IApplicationUserRolePermissionRepository: IDisposable
    {
        Task<bool> CreateAsync(ApplicationUserRolePermission applicationUserRolePermission, CancellationToken cancellationToken);
        bool Create(ApplicationUserRolePermission applicationUserRolePermission);
        Task<bool> UpdateAsync(ApplicationUserRolePermission applicationUserRolePermission, CancellationToken cancellationToken);
        bool Update(ApplicationUserRolePermission applicationUserRolePermission);
        Task<bool> DeleteAsync(ApplicationUserRolePermission applicationUserRolePermission, CancellationToken cancellationToken);
        bool Delete(ApplicationUserRolePermission applicationUserRolePermission);
        Task<IEnumerable<ApplicationUserRolePermission>> GetAllApplicationUserRolePermissionsAsync(string roleId);
        IEnumerable<ApplicationUserRolePermission> GetAllApplicationUserRolePermissions(string roleId);
        void Dispose();
    }
}
