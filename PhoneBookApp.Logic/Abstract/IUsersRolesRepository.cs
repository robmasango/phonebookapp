using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using eFindingsRegister.Model.Entities;

namespace eFindingsRegister.Logic.Abstract
{
    public interface IUsersRolesRepository {
        Task AddToRoleAsync(User user, string roleId);

        Task RemoveFromRoleAsync(User user, string roleId);

        bool RemoveFromRole(User user);

        bool FindRole(string roleId);
        Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken);
        Task<IEnumerable<Role>> GetRolesWithIdsAsync(User user, CancellationToken cancellationToken);

        void Dispose();
    }
}
