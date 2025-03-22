using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Driver;
using OrderDeliverySystemDataAccessLayer.Driver;

namespace OrderDeliverySystemAPi.Controllers.Driver
{
    [Route("api/Drivers")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        [HttpGet("GetDriverRating{id}")]
        public ActionResult<DriverDTO> GetDriver(int id)
        {
            DriverDTO Driver = DriverData.Get(id);
            if(Driver == null)
            {
                return NotFound("Driver Not Found");
            }
            return Ok(Driver);
        }
        [HttpGet("GetAllDriverRating")]
        public ActionResult<List<DriverService>> GetAll()
        {
            List<DriverDTO> DriverList = DriverData.GetAll();
            return Ok(DriverList);
        }
        [HttpDelete("DeleteDriverRating{id}")]
        public ActionResult<int> Delete(int id)
        {
            DriverDTO Driver = DriverData.Get(id);
            if (Driver == null || Driver.IsDeleted == true)
            {
                return BadRequest("There Are An Error");
            }else
            {
                DriverData.Delete(id);
                return Ok("Driver Done Successfully");
            }
           
        }
        [HttpPut("UpdateDriverRating")]
        public ActionResult<DriverService> Update(DriverDTO UpdatedDriver)
        {
            if (UpdatedDriver == null)
            {
                return NotFound("No Found");
            }
            DriverDTO Driver = DriverData.Get(UpdatedDriver.DriverID);
            Driver.PasswordHash = UpdatedDriver.PasswordHash;
            Driver.UserName = UpdatedDriver.UserName;
            Driver.VehicalLicense = UpdatedDriver.VehicalLicense;
            Driver.VehicalType = UpdatedDriver.VehicalType;
            Driver.Status = UpdatedDriver.Status;
            Driver.IsActive = UpdatedDriver.IsActive;
            DriverData.Update(Driver);
            return Ok(Driver);
        }
        [HttpPost("AddNewDriverRating")]
        public ActionResult<DriverService> AddNewDriver(DriverDTO NewDriver)
        { 
            if (NewDriver == null)
            {
                return BadRequest("Somthing Was Wrong");
            }
            DriverData.AddNew(NewDriver);
            return Ok(NewDriver);

        }
    }

}
