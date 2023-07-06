using BlazorSample.WebComponent.Models;
using BlazorSample.WebComponent.Repositories;
using System.Data.SqlClient;

namespace BlazorSample.WebComponent.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region Get Customer data
        /// <summary>
        /// Get all Customers List
        /// </summary>
        /// <returns></returns>
        public async Task<List<TBLUser>> GetCustomers()
        {
            try
            {
                var items = await _userRepository.GetCustomers();
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Customer data by Id
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        public async Task<TBLUser> GetUserDataById(int customerid)
        {
            try
            {
                var items = await _userRepository.GetUserDataById(customerid);
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Save Customer data
        /// <summary>
        /// Add Customer data
        /// </summary>
        /// <param name="customerData"></param>
        /// <returns></returns>
        public async Task<bool> AddCustomers(TBLUser customerData)
        {
            try
            {
                customerData.Createdon = DateTime.UtcNow;
                var result = await _userRepository.AddCustomers(customerData);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Customer Data
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCustomer(TBLUser obj)
        {
            try
            {
                var result = await _userRepository.UpdateCustomer(obj);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete Customer data
        /// <summary>
        /// Delete Customer data
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task DeleteUser(int customerId)
        {
            try
            {
                await _userRepository.DeleteUser(customerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
