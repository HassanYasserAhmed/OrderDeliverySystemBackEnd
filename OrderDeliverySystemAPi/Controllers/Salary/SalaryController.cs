using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.salary;
using OrderDeliverySystemBusinessLayer.salary;

namespace OrderDeliverySystemAPi.Controllers.Salary
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        [HttpGet("GetSalary{PersonID}")]
        public ActionResult<SalaryDTO> OrderByID(int PersonID)
        {
            var Order = SalaryData.Find(PersonID);
            if (Order == null)
            {
                return NotFound("Not Found");
            }
            return Ok(Order);
        }
        [HttpGet("GetAllSalaries{PersonID}")]
        public ActionResult<List<SalaryDTO>> GetAllSalaries(int PersonID)
        {
            List<SalaryDTO> SalariesList = SalaryData.FindAll(PersonID);

            if (SalariesList == null | SalariesList.Count == 0)

                return NotFound("No People Found");
            else
                return Ok(SalariesList);
        }


        [HttpDelete("DeleteSalary{PersonID}")]
        public ActionResult<int> DeleteOrder(int PersonID)
        {
            int IsDeleted = SalaryData.Delete(PersonID);
            if (IsDeleted == 0)
            {
                return NotFound($"Salary with ID {PersonID} not found.");
            }
            return Ok($"Salary with ID {PersonID} Deleted successfully.");
        }

        [HttpPut("UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SalaryDTO> UpdateOrder(SalaryDTO UpdatedSalary)
        {

            SalaryDTO order = SalaryData.Find(UpdatedSalary.PersonID);
            if (order == null)
            {
                return NotFound("Salary Not Found");
            }
            UpdatedSalary.PersonID = order.PersonID;
            int Result = SalaryData.Updated(UpdatedSalary);
            return Ok("Salary Updated Successfulle");
        }


        [HttpPost("AddNewSalary")]
        public ActionResult<SalaryDTO> AddNewArea(SalaryDTO NewOrder)
        {
            if (NewOrder == null)
            {
                return BadRequest("There Are An Error Try Again");
            }

            SalaryData.AddNew(NewOrder);
            return Ok($"Order Added Successfully");
        }
    }

}
