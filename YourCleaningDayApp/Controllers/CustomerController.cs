using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using YourCleaningDayApp.Data;
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
            var customer = DbContext.Customers.Include(customerAddr => customerAddr.Address).FirstOrDefault(cust => cust.CustomerId == id);

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
            return new JsonResult(customerList, DefaultJsonSettings);
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
