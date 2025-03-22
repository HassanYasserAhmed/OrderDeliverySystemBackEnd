using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Person;
using OrderDeliverySystemDataAccessLayer.Order;

namespace OrderDeliverySystemAPi.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        [HttpGet("GetOrder{OrderID}")]
        public ActionResult<OrderDTO> OrderByID(int OrderID)
        {
            var Order = OrderData.Find(OrderID);
            if (Order == null)
            {
                return NotFound("Not Found");
            }
            return Ok(Order);
        }
        [HttpGet("GetAll")]
        public ActionResult<List<OrderDTO>> GetAllPeople()
        {
            var PeopleList = OrderData.FindAll();

            if (PeopleList == null | PeopleList.Count == 0)

                return NotFound("No People Found");
            else
                return Ok(PeopleList);
        }


        [HttpDelete("DeleteOrder{OrderID}")]
        public ActionResult<int> DeleteOrder(int OrderID)
        {
            int IsDeleted = OrderData.Delete(OrderID);
            if (IsDeleted == 0)
            {
                return NotFound($"Person with ID {OrderID} not found.");
            }
            return Ok($"Person with ID {OrderID} Deleted successfully.");
        }

        [HttpPut("UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDTO> UpdateOrder(OrderDTO UpdatedOrder)
        {

            OrderDTO order = OrderData.Find(UpdatedOrder.OrderID);
            if (order == null)
            {
                return NotFound("Order Not Found");
            }
            UpdatedOrder.OrderID = order.OrderID;
            int Result = OrderData.Update(UpdatedOrder);
            return Ok("Order Updated Successfulle");
        }


        [HttpPost("AddNewPerson")]
        public ActionResult<OrderDTO> AddNewArea(OrderDTO NewOrder)
        {
            if (NewOrder == null)
            {
                return BadRequest("There Are An Error Try Again");
            }

            OrderData.Add(NewOrder);
            return Ok($"Order Added Successfully");
        }
    }
}
