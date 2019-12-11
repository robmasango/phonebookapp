using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using eFindingsRegister.Model.Entities;

namespace eFindingsRegister.Logic.Abstract
{
    public interface IUsersClaimsRepository
    {
        Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken);

        Task AddClaimsAsync(User user, IEnumerable<Claim> claims);

        Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim);

        void Dispose();
    }
}
