using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using eFindingsRegister.Model.Entities;
using Microsoft.AspNetCore.Identity;

namespace eFindingsRegister.Logic.Abstract
{
    public interface IUsersLoginsRepository {


        Task AddLoginAsync(User user, UserLoginInfo login);

        Task RemoveLoginAsync(User user, string loginProvider, string providerKey);

        Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken);

        Task<User> FindByLoginAsync(string loginProvider, string providerKey,
           CancellationToken cancellationToken);

        void Dispose();
    }
}
