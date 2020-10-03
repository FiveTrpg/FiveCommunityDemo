using Gaming.API.Infrastructure.Data.Community.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Gaming.API.Infrastructure.Data.Community
{
    public class FiveCommunityContext : ApiAuthorizationDbContext<FiveUser>
    {
        public DbSet<PersistedChannel> PersistedChannels { get; set; }
        public FiveCommunityContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersistedChannel>(table =>
            {
                table.HasIndex(col => col.Name);
                table.HasOne(channel => channel.Owner);
            });
            base.OnModelCreating(builder);
        }
    }
}
