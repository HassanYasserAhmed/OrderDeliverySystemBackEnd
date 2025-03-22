using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.DriverRating;
using OrderDeliverySystemDataAccessLayer.DriverRating;

namespace OrderDeliverySystemAPi.Controllers.DriverRating
{
    [Route("api/DriverRatings")]
    [ApiController]

    public class DriverRatingController : ControllerBase
    {
        [HttpGet("GetDriverRating{id}")]
        public ActionResult<DriverRatingDTO> GetDriver(int id)
        {
            DriverRatingDTO Driver = DriverRatingData.Get(id);
            if (Driver == null)
            {
                return NotFound("Driver Not Found");
            }
            return Ok(Driver);
        }
        [HttpGet("GetAllDriverRatings")]
        public ActionResult<List<DriverRatingService>> GetAll()
        {
            List<DriverRatingDTO> DriverList = DriverRatingData.GetAll();
            return Ok(DriverList);
        }
        [HttpDelete("DeleteDriverRating{OrderID}")]
        public ActionResult<int> Delete(int OrderID)
        {
            DriverRatingDTO DriverRating = DriverRatingData.Get(OrderID);
            if (DriverRating == null || DriverRating.IsDeleted == true)
            {
                return BadRequest("There Are An Error");
            }
            else
            {
                DriverRatingData.Delete(OrderID);
                return Ok("Driver Done Successfully");
            }

        }
        [HttpPut("UpdateDriverRating")]
        public ActionResult<DriverRatingService> Update(DriverRatingDTO UpdatedDriverRating)
        {
            if (UpdatedDriverRating == null)
            {
                return NotFound("No Found");
            }
            DriverRatingDTO DriverRating = DriverRatingData.Get(UpdatedDriverRating.OrderID);
            if (DriverRating == null)
            {
                return NotFound("No Rating Found");
            }
            DriverRating.Rating = UpdatedDriverRating.Rating;
            DriverRating.Review = UpdatedDriverRating.Review;
            DriverRating.DriverID = UpdatedDriverRating.DriverID;
            DriverRating.OrderID = UpdatedDriverRating.OrderID;

            DriverRatingData.Update(DriverRating);
            return Ok(DriverRating);
        }
        [HttpPost("AddNewDriverRating")]
        public ActionResult<DriverRatingService> AddNewD(DriverRatingDTO NewDriver)
        {
            if (NewDriver == null)
            {
                return BadRequest("Somthing Was Wrong");
            }
            DriverRatingData.AddNew(NewDriver);
            return Ok(NewDriver);

        }
    }
}
