using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemDataAccessLayer.Customer.CustomerPermissions;
using OrderDeliverySystemDataAccessLayer.Employee;

namespace OrderDeliverySystemAPi.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePermissionsController : ControllerBase
    {
        [HttpPut("ChangeEmployeePermissions")]
        public ActionResult<int> ChangeEmployeePermissions(EmployeePermissionsDTO ChangedEmployeePermissins)
        {
            if (ChangedEmployeePermissins == null)
            {
                return BadRequest("Invalid Employee permissions data.");
            }

            EmployeePermissionsData.Change(ChangedEmployeePermissins);
            return Ok("Employee Permissions changed successfully");
        }

        [HttpGet("GetEmployeePermissions{EmployeeID}")]

        public ActionResult<EmployeePermissionsDTO> GetCustomerPermissions(int EmployeeID)
        {
            EmployeePermissionsDTO employeePermissions = EmployeePermissionsData.Get(EmployeeID);
            if (employeePermissions == null)
            {
                return BadRequest("There Are An Error Accoured");
            }
            return Ok(employeePermissions);
        }
    }
}
