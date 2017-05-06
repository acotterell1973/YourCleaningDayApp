using System;
using System.Threading.Tasks;

namespace YourCleaningDayApp.Data
{
    public class DbSeeder
    {
        #region Private members
        private readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructory
        public DbSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public Methods

        //public async Task SeedAsync()
        //{
        //    _dbContext.Database.EnsureCreated();
        //    //  if (await _dbContext.Users.CountAsync() == 0) CreateUsers();
        //    //  if (await _dbContext.Tenants.CountAsync() == 0) CreateTenants();
        //    //  if (await _dbContext.Customers.CountAsync() == 0) CreateCustomers();
        //}

        private void CreateCustomers()
        {
            DateTime createdDate = new DateTime(2017,03,01,12,30,00);
            DateTime modifiedDate = DateTime.Now;

#if DEBUG

#endif
        }

        private void CreateTenants()
        {
            throw new NotImplementedException();
        }

        private void CreateUsers()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
