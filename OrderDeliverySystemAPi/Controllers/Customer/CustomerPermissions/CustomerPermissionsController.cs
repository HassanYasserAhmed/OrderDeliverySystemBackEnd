using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Customer.CustomerPermissions;
using OrderDeliverySystemDataAccessLayer.Customer.CustomerPermissions;

namespace OrderDeliverySystemAPi.Controllers.Customer.CustomerPermissions
{
    [Route("api/CustomerPermissions")]
    [ApiController]
    public class CustomerPermissionsController : ControllerBase
    {
        [HttpPut("ChangeCustomerPermissions")]
        public ActionResult<int> ChangeCustomerPermissions(CustomerPermissionsDTO changedCustomerPermissions)
        {
            if (changedCustomerPermissions == null)
            {
                return BadRequest("Invalid customer permissions data.");
            }

            CustomerPermissionsData.ChangeCustomerPermissions(changedCustomerPermissions);
            return Ok("Customer Permissions changed successfully");
        }

        [HttpGet("GetCustomerPermissions{CustomerID}")]

        public ActionResult<CustomerPermissionsDTO> GetCustomerPermissions(int CustomerID)
        {
          CustomerPermissionsDTO customerPermissions=CustomerPermissionsData.Get(CustomerID);
            if(customerPermissions == null)
            {
                return BadRequest("There Are An Error Accoured");
            }
            return Ok(customerPermissions);
        }
    }
}
