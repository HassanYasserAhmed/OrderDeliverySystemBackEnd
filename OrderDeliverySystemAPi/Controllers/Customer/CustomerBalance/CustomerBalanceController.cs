using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Customer.CustoemerBalance;
using OrderDeliverySystemDataAccessLayer.Customer.CustomerBalance;

namespace OrderDeliverySystemAPi.Controllers.Customer.CustomerBalanceController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBalanceController : ControllerBase
    {
        [HttpGet("GetCurrentBalance")]
        public ActionResult<CustomerBalanceDTO> GetCurrentBalance(int CustomerID)
        {
            CustomerBalanceService CurrentBalance = CustomerBalanceService.Get(CustomerID);
            if (CurrentBalance == null)
            {
                return BadRequest("Somthing was Error");
            }
            return Ok(CurrentBalance.CBDTO);
        }
        [HttpPut("CreditBalance")]
        public ActionResult<int> CreditDebitBalance(CustomerBalanceDTO UpdatedBalance)
        {
            int Result = CustomerBalanceData.CreditDebitBalance(UpdatedBalance.Balance, UpdatedBalance.CustomerID);
            return Ok("Credit Done Successfylly");
        }

        [HttpPut("DebitBalance")]
        public ActionResult<int> DebitBalance(CustomerBalanceDTO UpdatedBalance)
        {
            decimal CurrentBalance = CustomerBalanceData.Get(UpdatedBalance.CustomerID).Balance;
            if(CurrentBalance < UpdatedBalance.Balance)
            {
                return BadRequest("You Don't Have Enough Balance IN");
            }
            int Result = CustomerBalanceData.CreditDebitBalance(-UpdatedBalance.Balance, UpdatedBalance.CustomerID);
            return Ok("Debit Done Successfully");
        }
    }

}
