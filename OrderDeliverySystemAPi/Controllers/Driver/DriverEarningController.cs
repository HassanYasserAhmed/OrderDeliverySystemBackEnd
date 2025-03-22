using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Driver;
using OrderDeliverySystemDataAccessLayer.Driver;

namespace OrderDeliverySystemAPi.Controllers.Driver
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverEarningController : ControllerBase
    {

        [HttpGet("GetDriverEarning{OrderID}")]
        public ActionResult<DriverEarningDTO> GetDriverEarningOrderID(int OrderID)
        {
            DriverEarningDTO DriversList = DriverEarningData.Get(OrderID);
            if (DriversList == null)
            {
                return NotFound("Driver Not Found");
            }
            return Ok(DriversList);
        }

        [HttpGet("GetAllDriverEarning{DriverID}")]
        public ActionResult<DriverEarningDTO> GetDriverAllEarning(int DriverID)
        {
            List<DriverEarningDTO> DriversList = DriverEarningData.GetAll(DriverID);
            if (DriversList == null)
            {
                return NotFound("Driver Not Found");
            }
            return Ok(DriversList);
        }
        
        [HttpPut("UpdateDriverRating")]
        public ActionResult<DriverService> Update(DriverEarningDTO UpdatedDriver)
        {
            if (UpdatedDriver == null)
            {
                return NotFound("No Found");
            }
            DriverEarningDTO DriverArning = DriverEarningData.Get(UpdatedDriver.OrderID);
            DriverArning.DriverID = UpdatedDriver.DriverID;
            DriverArning.Amount = UpdatedDriver.Amount;
            DriverEarningData.Update(DriverArning);
            return Ok(DriverArning);
        }
        [HttpPost("AddNewDriverRating")]
        public ActionResult<DriverService> AddNewDriver(DriverEarningDTO NewDriver)
        {
            if (NewDriver == null)
            {
                return BadRequest("Somthing Was Wrong");
            }
            DriverEarningData.AddNew(NewDriver);
            return Ok(NewDriver);

        }
    }
}
