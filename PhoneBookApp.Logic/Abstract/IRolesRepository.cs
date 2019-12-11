using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using eFindingsRegister.Model.Entities;
using Microsoft.AspNetCore.Identity;

namespace eFindingsRegister.Logic.Abstract
{ 
    public interface IRolesRepository {
        Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken);

        Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken);

        Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken);

        Task<Role> FindByIdAsync(string roleId);

        Task<Role> FindByNameAsync(string normalizedRoleName);

        Task<IEnumerable<Role>> GetAllRoles();
        Role CreateRole(AddRoleRequest request);

        Role UpdateRole(AddRoleRequest request);
        void Dispose();
    }
}
