using BlazorSample.WebComponent.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorSample.WebComponent.Repositories
{
    public class UserRepository
    {
        #region Property
        private readonly IDbContextFactory<DatabaseContext> _dbContextFactory;
        #endregion

        #region Constructor
        public UserRepository(IDbContextFactory<DatabaseContext> databasecontext)
        {
            _dbContextFactory = databasecontext;
        }
        #endregion

        #region Get List of User
        public async Task<List<TBLUser>> GetCustomers()
        {
            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();
                var data = await _dbContext.TBLUser.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Customer Data By CustomerID
        public async Task<TBLUser> GetUserDataById(int customerid)
        {
            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();
                var data = await _dbContext.TBLUser.FirstOrDefaultAsync(x => x.CustomerId == customerid);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert the Customer Record 
        public async Task<bool> AddCustomers(TBLUser customerData)
        {
            using var _dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                _dbContext.TBLUser.Add(customerData);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region update the customer record 
        public async Task<bool> UpdateCustomer(TBLUser customerData)
        {
            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();
                var data = await _dbContext.TBLUser.FirstOrDefaultAsync(x => x.CustomerId == customerData.CustomerId);
                if (data != null)
                {
                    data.FirstName = customerData.FirstName;
                    data.LastName = customerData.LastName;
                    data.EmailId = customerData.EmailId;
                    data.Phonenumber = customerData.Phonenumber;
                    data.City = customerData.City;
                    data.State = customerData.State;
                    data.Country = customerData.Country;
                    data.Modifiedby = customerData.Modifiedby;
                    data.Modifiedon = DateTime.UtcNow;
                    data.IsActive = customerData.IsActive;
                    data.ZipCode = customerData.ZipCode;

                    _dbContext.TBLUser.Update(data);
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region delete the customer record
        public async Task DeleteUser(int customerId)
        {
            using var _dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                var customerData = await _dbContext.TBLUser.FirstOrDefaultAsync(x => x.CustomerId == customerId);
                if (customerData != null)
                {
                    _dbContext.TBLUser.Remove(customerData);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
