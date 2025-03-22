using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Customer.CustomerTransactions;
using OrderDeliverySystemDataAccessLayer.Customer.CustomerTransactions;

namespace OrderDeliverySystemAPi.Controllers.Customer.CustomerTransaction
{
    [Route("api/CustomerTransActions")]
    [ApiController]
    public class CustomerTransactionController : ControllerBase
    {
        [HttpGet("GetAllCustomerTransactions{CustomerID}")]
        public ActionResult<List<CustomerTranactionsService>> GetAllCustomerTransActions(int CustomerID)
        {
            List<CustomerTranactionsDTO> CustomerTransActionsList = CustomerTransActionsData.FindAll(CustomerID);
            if (CustomerTransActionsList == null)
            {
                return NotFound("Not transActions Accured Yet");
            }

            return Ok(CustomerTransActionsList);
        }
        [HttpPost("AddNewcustomerTransactions")]
        public ActionResult<CustomerTranactionsService> AddNewCustomerTrasaction(CustomerTranactionsDTO NewCustomerTransaction)
        {
            if(NewCustomerTransaction == null)
            {
                return BadRequest("There Are An Error Accurred");
            }
           int Result = CustomerTransActionsData.AddNew(NewCustomerTransaction);
         return Ok("Trasaction Done Successfully");
        }
    }
}
