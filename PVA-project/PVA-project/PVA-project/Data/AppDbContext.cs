using Microsoft.EntityFrameworkCore;
using PVA_project.Data.Classes;

namespace PVA_project
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {

        }

        public DbSet<CompanyKeys> CompanyKeys { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }
    }
}
