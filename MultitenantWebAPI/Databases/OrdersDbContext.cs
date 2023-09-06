using Microsoft.EntityFrameworkCore;
using MultitenantWebAPI.Entities;
using MultitenantWebAPI.Tenants;

namespace MultitenantWebAPI.Databases
{
    public class OrdersDbContext : DbContext
    {
        private readonly string _tenantId;

        public OrdersDbContext
        (
            DbContextOptions<OrdersDbContext> options,
            TenantProvider tenantProvider
        ) : base(options) 
        {
            _tenantId = tenantProvider.TenantId;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder
                .Entity<Order>()
                .HasQueryFilter(o => o.TenantId == _tenantId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
