using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemDataAccessLayer.Order;
using RevenueDeliverySystemDataAccessLayer.Revenue;

namespace OrderDeliverySystemAPi.Controllers.Revenue
{
    [Route("api/[controller]")]
    [ApiController]

    public class RevenueController : ControllerBase
    {
        [HttpGet("GetRevenue{RevenueID}")]
        public ActionResult<RevenueDTO> OrderByID(int RevenueID)
        {
            var Order = RevenueData.Find(RevenueID);
            if (Order == null)
            {
                return NotFound("Not Found");
            }
            return Ok(Order);
        }
        [HttpGet("GetAllRevenues")]
        public ActionResult<List<RevenueDTO>> GetAllPeople()
        {
            var PeopleList = RevenueData.FindAll();

            if (PeopleList == null | PeopleList.Count == 0)

                return NotFound("No Revenues Found");
            else
                return Ok(PeopleList);
        }


        [HttpDelete("DeleteRevenue{RevenueID}")]
        public ActionResult<int> DeleteOrder(int RevenueID)
        {
            int IsDeleted = RevenueData.Delete(RevenueID);
            if (IsDeleted == 0)
            {
                return NotFound($"Revenue with ID {RevenueID} not found.");
            }
            return Ok($"Revenue with ID {RevenueID} Deleted successfully.");
        }

        [HttpPut("UpdateRevenue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RevenueDTO> UpdateRevenue(RevenueDTO UpdatedRevenue)
        {

            RevenueDTO order = RevenueData.Find(UpdatedRevenue.RevenueID);
            if (order == null)
            {
                return NotFound("Revenue Not Found");
            }
            UpdatedRevenue.RevenueID = order.RevenueID;
            int Result = RevenueData.Update(UpdatedRevenue);
            return Ok("Revenue Updated Successfulle");
        }


        [HttpPost("AddNewRevenue")]
        public ActionResult<RevenueDTO> AddNewArea(RevenueDTO NewOrder)
        {
            if (NewOrder == null)
            {
                return BadRequest("There Are An Error Try Again");
            }

            RevenueData.Add(NewOrder);
            return Ok($"Revenue Added Successfully");
        }
    }
}
