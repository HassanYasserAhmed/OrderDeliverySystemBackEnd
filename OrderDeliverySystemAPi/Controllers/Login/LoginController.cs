using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Login;

namespace OrderDeliverySystemAPi.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public class LoginController : ControllerBase
    {
        [HttpGet("LoginByUserNameAndPassword")]
        public ActionResult<string> Login(LoginDTO Login)
        {
            if (Login == null)
            {
                return NotFound("Invalid UserName Or Password1");
            }
            else
            {
                string Role = LoginService.LoginByUserNameAndPassword(Login.UserName, Login.Password);
                if (Role == null | Role == "")
                {
                    return NotFound("Invalid UserName Or Password2");
                }
                else
                {
                    return Ok(Role);
                }
            }
        }
    }
}
