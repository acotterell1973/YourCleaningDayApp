using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using YourCleaningDayApp.Data;
using YourCleaningDayApp.Data.Addresses;
using YourCleaningDayApp.Data.Customers;
using YourCleaningDayApp.ViewModels;

namespace YourCleaningDayApp.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        #region Constructor
        public CustomerController(ApplicationDbContext context)
        {
            DbContext = context;
        }
        #endregion


        /// <summary>
        /// Prevent the default get without parameters
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found." });
        }

        /// <summary>
        /// Get customer by their id
        /// GET: /customer/{id}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Json-serialized object representing the customer</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer =
                DbContext.Customers.Include(customerAddr => customerAddr.Address)
                    .FirstOrDefault(cust => cust.CustomerId == id);
            if (customer == null) return NotFound(new { Error = $"Item Id {id} not found." });

            var customerVm = TinyMapper.Map<CustomerViewModel>(customer);
            return new JsonResult(customerVm, DefaultJsonSettings);
        }
        /// <summary>
        /// Get a list of the most recent customers
        /// GET: /customer/mostrecent
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of n Json-serialized objects represting the latest created customers</returns>
        [HttpGet("mostrecent")]
        public IActionResult GetMostRecentCustomers()
        {
            var customerList = GetMostRecentCustomersBy(DefaultNumberOfRecords);
            return customerList;
        }

        /// <summary>
        /// Get a list of the most recent customers
        /// GET: /customer/mostrecent/{numberOfRows}
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of n Json-serialized objects represting the latest created customers</returns>
        [HttpGet("mostrecent/{numberOfRows}")]
        public IActionResult GetMostRecentCustomersBy(int numberOfRows)
        {
            if (numberOfRows > MaximumNumberOfRecords) numberOfRows = MaximumNumberOfRecords;
            var customers = DbContext.Customers.Include(customerAddr => customerAddr.Address).OrderByDescending(cust => cust.CreatedDate).Take(numberOfRows).ToArray();
            var customerList = ToCustomerViewModelList(customers);
            return new JsonResult(customerList, DefaultJsonSettings);
        }

        /// <summary>
        /// POST: /api/customer
        /// </summary>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult AddCustomer([FromBody]CustomerViewModel customerViewModel)
        {
            //if payload is invalid
            if (customerViewModel == null) return new StatusCodeResult(500);

            var customer = TinyMapper.Map<Customer>(customerViewModel);
            var customerAddress = TinyMapper.Map<Address>(customerViewModel);
            customer.CreatedDate = (DateTime)(customer.ModifiedDate = DateTime.Now);
            customer.CreatedUserId = 1966;
            customerAddress.CreatedDate = (DateTime)(customerAddress.ModifiedDate = DateTime.Now);
            customerAddress.CreatedUserId = 1966;
            customer.Address = customerAddress;
            DbContext.Customers.Add(customer);
            DbContext.SaveChanges();

            return new JsonResult(TinyMapper.Map<CustomerViewModel>(customer), DefaultJsonSettings);
        }

        /// <summary>
        /// PUT:  api/customer/{customerId}
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customerViewModel"></param>
        /// <returns></returns>
        [HttpPut()]
        public IActionResult UpdateCustomer(int customerId, [FromBody]CustomerViewModel customerViewModel)
        {

            if (customerViewModel == null) return NotFound(new {Error = $"CustomerId {customerId} not found."});

            var userId = 1966;
            var customer = DbContext.Customers.Include(custAddress=>custAddress.Address).FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null) return new StatusCodeResult(500);

            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;
            customer.PrimaryPhoneNumber = customerViewModel.PhoneNumber;
            customer.PrimaryEmailAddress = customerViewModel.EmailAddress;
            customer.Gender = customerViewModel.Gender;
            customer.Address.Address1 = customerViewModel.Address1;
            customer.Address.Address2 = customerViewModel.Address2;
            customer.Address.City = customerViewModel.City;
            customer.Address.StateId = customerViewModel.State;
            customer.Address.Zipcode = customerViewModel.Zip;
            
            customer.ModifiedDate = DateTime.Now;
            customer.ModifiededUserId = userId;
            customer.Address.ModifiedDate = DateTime.Now;
            customer.Address.ModifiededUserId = userId;
            DbContext.SaveChanges();

            return new JsonResult(TinyMapper.Map<CustomerViewModel>(customer), DefaultJsonSettings);
        }

        /// <summary>
        /// DELETE: api/customer/{customerId}
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public IActionResult DisableCustomer(int customerId)
        {
            var customer = DbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null) return NotFound(new { Error = $"CustomerId {customerId} not found." }); 
            customer.Active = false;
            DbContext.SaveChanges();
            return new OkResult();
        }

        #region Private Members
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers">An IEnumerable collection of customers= entities</param>
        /// <returns>A mapped list of CustomerViewModel objects</returns>
        private List<CustomerViewModel> ToCustomerViewModelList(IEnumerable<Customer> customers)
        {
            return customers.Select(TinyMapper.Map<CustomerViewModel>).ToList();
        }
        #endregion
    }
}
