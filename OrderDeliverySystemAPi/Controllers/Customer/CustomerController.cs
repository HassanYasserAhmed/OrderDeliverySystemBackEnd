using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Customer;
using OrderDeliverySystemDataAccessLayer.Customer;
namespace OrderDeliverySystemAPi.Controllers.Customer
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("GetCustomer{id}", Name = "GetCustomer")]

        public ActionResult<CustomerService> Find(int id)
        {
            var Customer = CustomerData.Find(id);
            if (Customer == null)
            {
                return NotFound($"Customer With ID {id} Not Found");
            }
            return Ok(Customer);
        }
        [HttpGet("GetAllCustomers", Name = "GetAllCustomers")]
        public ActionResult<List<CustomerService>> GetAllCustomers()
        {
            var CustomersList = CustomerData.FindAll();
            if (CustomersList == null)
            {
                return NotFound("No Customers Found");
            }
            return Ok(CustomersList);
        }

        [HttpPost("AddNewCustomer")]
        public ActionResult<CustomerData> AddNewCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest("There Are An Error Try Again Later");
            }

            CustomerData.AddNew(customerDTO);
            return Ok("Customer Added Successfully");
        }

        [HttpDelete("DeleteCustomer{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            int Result = CustomerData.Delete(id);
            if (Result == 0)
            {
                return BadRequest("Some Error Accoured");
            }
            return Ok($"Customer With Id {id} has been Deleted Successfully");
        }
        [HttpPut("UpdateCustomer")]
        public ActionResult<CustomerService> UpdateCustomer(CustomerDTO UpdatedCustomer)
        {
            if (UpdatedCustomer == null)
            {
                return BadRequest("There is An Error Try Again");
            }
            CustomerService Customer = new CustomerService(CustomerData.Find(UpdatedCustomer.CustomerID));
            Customer.UserName = UpdatedCustomer.UserName;
            Customer.PasswordHash = UpdatedCustomer.PasswordHash;
            Customer.Status = UpdatedCustomer.Status;
            Customer.IsActive = UpdatedCustomer.IsActive;
            Customer.CustomerID = UpdatedCustomer.CustomerID;

            CustomerData.Update(Customer.CDTO);
            return Ok("Customer Updated Successfully");
        }


    }
}
