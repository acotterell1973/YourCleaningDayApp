using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace YourCleaningDayApp.Controllers
{
    [Route("api/[controller]")]
    public class StaffController : BaseController
    {

        /// <summary>
        /// Prevent the default get without parameters
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new {Error = "not found."});
        }

        /// <summary>
        /// Get an employee by their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return NotFound(new { Error = "not found." });
        }

        /// <summary>
        /// Get a list of employees
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployees")]
        public JsonResult GetEmployees()
        {
            return new JsonResult(new string[] { "value1", "value2" }, DefaultJsonSettings) ;
        }
        
    }
}
