using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Customer;
using OrderDeliverySystemBusinessLayer.Person;
using OrderDeliverySystemDataAccessLayer.Customer;
using OrderDeliverySystemDataAccessLayer.People;

namespace OrderDeliverySystemAPi.Controllers.Login
{
    public class RegestrationInfoDTO
    {
        public RegestrationInfoDTO(string fullName, string email, string phoneNumber,
            string birthDate, int areaID, string userName, string passwordHash)
        {
            this.fullName = fullName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.birthDate = birthDate;
            this.areaID = areaID;
            this.userName = userName;
            this.passwordHash = passwordHash;
        }
        public RegestrationInfoDTO() { }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string birthDate { get; set; }
        public int areaID { get; set; }
        public string userName { get; set; }
        public string passwordHash { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class testRegestrion : ControllerBase
    {
        [HttpPost("testRegesteration")]
        public ActionResult<RegestrationInfoDTO> Get(RegestrationInfoDTO NewReg)
        {
            DataAccessPersonDTO NewPerson = new DataAccessPersonDTO();
            NewPerson.FullName = NewReg.fullName;
            NewPerson.Email = NewReg.email;
            NewPerson.PhoneNumber = NewReg.phoneNumber;
            NewPerson.BirthDate = NewReg.birthDate;
            NewPerson.AreaID = NewReg.areaID;
            int PersonID = PersonService.AddNewPerson(NewPerson);
            CustomerDTO NewCustomer = new CustomerDTO(0, PersonID, NewReg.userName, NewReg.passwordHash, "New", true, "2002-11-11", "2002-11-11", false);
            int Result = CustomerData.AddNew(NewCustomer);
            return Ok(Result);
        }
    }
}
