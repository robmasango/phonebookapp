using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eFindingsRegister.Model.Entities;
using Microsoft.AspNetCore.Identity;

namespace eFindingsRegister.Logic.Utils
{
    public interface IRoleStore
    {
        IQueryable<Role> Roles();

        Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken);

        Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken);

        Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken);

        Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken);

        Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken);

        Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken);

        Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken);

        Task SetNormalizedRoleNameAsync(Role role, string normalizedName,
           CancellationToken cancellationToken);

        Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken);

        Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken);

        void Dispose();
    }
}
