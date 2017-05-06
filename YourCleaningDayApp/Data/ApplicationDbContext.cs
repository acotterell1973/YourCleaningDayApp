using Microsoft.EntityFrameworkCore;
using YourCleaningDayApp.Data.Addresses;
using YourCleaningDayApp.Data.Customers;
using YourCleaningDayApp.Data.Employees;
using YourCleaningDayApp.Data.Tenants;
using YourCleaningDayApp.Data.Users;

namespace YourCleaningDayApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        public ApplicationDbContext(DbContextOptions options) : base (options)
        {

        }
        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");

            modelBuilder.Entity<Tenant>().ToTable("Tenants");
            modelBuilder.Entity<Tenant>().Property(i => i.TenantId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tenant>().HasMany(i => i.Employees);

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().Property(i => i.EmployeeId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<ReferredBy.ReferredBy>().ToTable("ReferredBy");
        }
        #endregion

        #region Properties
        
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<ReferredBy.ReferredBy> ReferredBy { get; set; }
        #endregion
    }
}
