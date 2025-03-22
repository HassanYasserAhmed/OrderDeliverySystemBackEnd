using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Admin;
//using OrderDeliverySystemBusinessLayer.Person;
using OrderDeliverySystemDataAccessLayer.Admin;
//using OrderDeliverySystemDataAccessLayer.People;

namespace OrderDeliverySystemAPi.Controllers.Admin
{
    [Route("api/Admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet("GetAdmin")]
        public ActionResult<AdminService> GetAdmin()
        {
            var person = AdminData.Find();
            if (person == null)
            {
                return NotFound("Admin Not Found");
            }
            return Ok(person);
        }

        [HttpPut("UpdateAdmin")]
        public ActionResult<int> UpdateAdmin(AdminDTO UpdatedAdmin)
        {
            AdminService Admin = AdminService.Find();

            Admin.UserName = UpdatedAdmin.UserName;
            Admin.PasswordHash = UpdatedAdmin.PasswordHash;


            int Results = AdminData.Update(Admin.ADTO);
            if (Results > 0)
            {
                return Ok("Admin Updated Successfully");
            }

            return BadRequest("There are some errors try again");
        }
    }
}
