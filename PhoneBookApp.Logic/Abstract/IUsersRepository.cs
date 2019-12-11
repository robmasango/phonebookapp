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
    public interface IUsersRepository {
        Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken);

        Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken);

        Task<User> FindByIdAsync(string userId);

        Task<User> FindByNameAsync(string normalizedUserName);

        Task<User> FindByEmailAsync(string normalizedEmail);

        Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken);

        Task<IEnumerable<User>> GetAllUsers();


        Task<User> FinduserByIdSupplierIdAsync(string supplierId);


       /// Task<IdentityResult> EmaillingAsync(string SendTo, string Sendcc, string Subject, string Message, string AttachmentPath);
        void Dispose();
    }
}
