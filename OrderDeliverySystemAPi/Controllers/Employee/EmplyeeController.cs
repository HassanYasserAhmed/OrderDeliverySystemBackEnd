using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Employee;
using OrderDeliverySystemDataAccessLayer.Employee;

namespace OrderDeliverySystemAPi.Controllers.Employee
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("GetEmployee{id}", Name = "GetEmployee")]

        public ActionResult<EmployeeService> Find(int id)
        {
            var Employee = EmployeeData.Get(id);
            if (Employee == null)
            {
                return NotFound($"Employee With ID {id} Not Found");
            }
            return Ok(Employee);
        }
        [HttpGet("GetAllEmployees", Name = "GetAllEmployees")]
        public ActionResult<List<EmployeeService>> GetAllEmployees()
        {
            var EmployeesList = EmployeeData.GetAll();
            if (EmployeesList == null)
            {
                return NotFound("No Employees Found");
            }
            return Ok(EmployeesList);
        }

        [HttpPost("AddNewEmployee")]
        public ActionResult<EmployeeData> AddNewEmployee(EmployeeDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest("There Are An Error Try Again Later");
            }

            EmployeeData.AddNew(customerDTO);
            return Ok("Employee Added Successfully");
        }

        [HttpDelete("DeleteEmployee{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            int Result = EmployeeData.Delete(id);
            if (Result == 0)
            {
                return BadRequest("Some Error Accoured");
            }
            return Ok($"Employee With Id {id} has been Deleted Successfully");
        }
        [HttpPut("UpdateEmployee")]
        public ActionResult<EmployeeService> UpdateEmployee(EmployeeDTO UpdatedEmployee)
        {
            if (UpdatedEmployee == null)
            {
                return BadRequest("There is An Error Try Again");
            }
            EmployeeService Employee = new EmployeeService(EmployeeData.Get(UpdatedEmployee.EmployeeID));
            Employee.UserName = UpdatedEmployee.UserName;
            Employee.PasswordHash = UpdatedEmployee.PasswordHash;
            Employee.Status = UpdatedEmployee.Status;
            Employee.IsActive = UpdatedEmployee.IsActive;
            Employee.EmployeeID = UpdatedEmployee.EmployeeID;

            EmployeeData.Update(Employee.EDTO);
            return Ok("Employee Updated Successfully");
        }


    }
}
