using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemDataAccessLayer.DriverPermissions;

namespace OrderDeliverySystemAPi.Controllers.DriverPermissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverPermissionsController : ControllerBase
    {
        [HttpGet("GetDriverPermissions{DriverID}")]
        public ActionResult<DriverPermissionsDTO> GetDriver(int DriverID)
        {
            DriverPermissionsDTO CurrentDriverPermissions = DriverPermissionsData.Get(DriverID);
            if (CurrentDriverPermissions == null)
            {
                return NotFound("Driver Not Found");
            }
            return Ok(CurrentDriverPermissions);
        }
      
       
        [HttpPut("ChangeDriverPermissions")]
        public ActionResult<int> Update(DriverPermissionsDTO UpdatedDriverPermissions)
        {
            DriverPermissionsDTO DriverPermissions = DriverPermissionsData.Get(UpdatedDriverPermissions.DriverID);

            if (UpdatedDriverPermissions == null || DriverPermissions == null)
            {
                return BadRequest("There Are An Error");
            }
            UpdatedDriverPermissions.DriverPermissionsID = DriverPermissions.DriverPermissionsID;
            DriverPermissionsData.Change(UpdatedDriverPermissions);
            return Ok(DriverPermissions);
        }
       
    }
}
