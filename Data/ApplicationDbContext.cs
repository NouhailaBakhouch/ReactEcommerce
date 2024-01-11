using Duende.IdentityServer.EntityFramework.Options;
using EcommerceReact.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EcommerceReact.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Produit> Produits { get; set; }
    }
}