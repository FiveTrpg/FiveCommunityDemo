using Gaming.API.Infrastructure.Data.FiveUsers.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Gaming.API.Infrastructure.Data.FiveUsers
{
    public class FiveUserContext : ApiAuthorizationDbContext<FiveUser>
    {
        public FiveUserContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
