using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.salary;
using OrderDeliverySystemDataAccessLayer.SystemSetting;

namespace OrderDeliverySystemAPi.Controllers.SystemSetting
{
    [Route("api/[controller]")]
    [ApiController]

    public class SystemSetting : ControllerBase
    {
        [HttpGet("GetSetting{SettingID}")]
        public ActionResult<SystemSettingDTO> GetSystemSettinByID(int SettingID)
        {
            var Order = SystemSettinData.Find(SettingID);
            if (Order == null)
            {
                return NotFound("Not Found");
            }
            return Ok(Order);
        }
        [HttpGet("GetAllSystemSetting")]
        public ActionResult<List<SystemSettingDTO>> GetAllSalaries()
        {
            List<SystemSettingDTO> SystemSettingList = SystemSettinData.FindAll();

            if (SystemSettingList == null | SystemSettingList.Count == 0)

                return NotFound("No Setting Found");
            else
                return Ok(SystemSettingList);
        }


        [HttpDelete("DeleteSetting{SettingID}")]
        public ActionResult<int> DeleteSetting(int SettingID)
        {
            int IsDeleted = SystemSettinData.Delete(SettingID);
            if (IsDeleted == 0)
            {
                return NotFound($"Setting with ID {SettingID} not found.");
            }
            return Ok($"Setting with ID {SettingID} Deleted successfully.");
        }

        [HttpPut("UpdateSetting")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SystemSettingDTO> UpdateOrder(SystemSettingDTO UpdatedSystemSetting)
        {

            SystemSettingDTO SystemSetting = SystemSettinData.Find(UpdatedSystemSetting.SystemSettingID);
            if (SystemSetting == null)
            {
                return NotFound("Setting Not Found");
            }
            UpdatedSystemSetting.SystemSettingID = SystemSetting.SystemSettingID;
            int Result = SystemSettinData.Updated(UpdatedSystemSetting);
            return Ok("Setting Updated Successfulle");
        }


        [HttpPost("AddNewSetting")]
        public ActionResult<SystemSettingDTO> AddNew(SystemSettingDTO NewSystemSetting)
        {
            if (NewSystemSetting == null)
            {
                return BadRequest("There Are An Error Try Again");
            }

            SystemSettinData.AddNew(NewSystemSetting);
            return Ok($"Setting Added Successfully");
        }
    }
}
