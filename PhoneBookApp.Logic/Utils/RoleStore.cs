using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eFindingsRegister.Logic.Abstract;
using eFindingsRegister.Model.Entities;
using Microsoft.AspNetCore.Identity;
namespace eFindingsRegister.Logic.Utils
{
    public class RoleStore : IQueryableRoleStore<Role>, IRoleStore
    {
        private readonly IRolesRepository _rolesRepository;

        public RoleStore(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public IQueryable<Role> Roles => (Task.Run(() => _rolesRepository.GetAllRoles()).Result.AsQueryable());

        IQueryable<Role> IRoleStore.Roles()
        {
            return Roles;
        }

        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Parameter role is not set to an instance of an object.");
            }

            return _rolesRepository.CreateAsync(role, cancellationToken);
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Parameter role is not set to an instance of an object.");
            }

            return _rolesRepository.UpdateAsync(role, cancellationToken);
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Parameter role is not set to an instance of an object.");
            }

            return _rolesRepository.DeleteAsync(role, cancellationToken);
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Parameter role is not set to an instance of an object.");
            }

            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(role.Id);
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Parameter role is not set to an instance of an object.");
            }

            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Parameter role is not set to an instance of an object.");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException(nameof(roleName), "Parameter roleName cannot be null or empty.");
            }

            cancellationToken.ThrowIfCancellationRequested();
            role.Name = roleName;
            return Task.FromResult<object>(null);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Parameter role is not set to an instance of an object.");
            }

            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(role.NormalizedName);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Parameter role is not set to an instance of an object.");
            }

            if (string.IsNullOrEmpty(normalizedName))
            {
                throw new ArgumentNullException(nameof(normalizedName), "Parameter normalizedName cannot be null or empty.");
            }

            cancellationToken.ThrowIfCancellationRequested();
            role.NormalizedName = normalizedName;
            return Task.FromResult<object>(null);
        }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(roleId))
            {
                throw new ArgumentNullException(nameof(roleId), "Parameter roleId cannot be null or empty.");
            }

            cancellationToken.ThrowIfCancellationRequested();
            return _rolesRepository.FindByIdAsync(roleId);
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(normalizedRoleName))
            {
                throw new ArgumentNullException(nameof(normalizedRoleName), "Parameter normalizedRoleName cannot be null or empty.");
            }

            cancellationToken.ThrowIfCancellationRequested();
            return _rolesRepository.FindByNameAsync(normalizedRoleName);
        }

        public void Dispose()
        {
            _rolesRepository.Dispose();
        }
    }
}
