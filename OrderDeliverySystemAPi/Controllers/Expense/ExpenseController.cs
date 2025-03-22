using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderDeliverySystemBusinessLayer.Expense;
using OrderDeliverySystemBusinessLayer.Expense;
using OrderDeliverySystemDataAccessLayer.Expense;
using OrderDeliverySystemDataAccessLayer.Expense;

namespace OrderDeliverySystemAPi.Controllers.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        [HttpGet("GetExpense{id}")]
        public ActionResult<ExpenseDTO> Find(int id)
        {
            ExpenseDTO Expense = ExpenseData.Find(id);
            if (Expense == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(Expense);
        }






        [HttpGet("GeteAllExpenses")]
        public ActionResult<List<ExpenseService>> GetAllExpenses()
        {
            List<ExpenseDTO> Expenses = ExpenseData.FindAll();
            if (Expenses == null)
            {
                return NotFound("Expense Not Found");
            }
            return Ok(Expenses);
        }

        [HttpPost("AddNewExpense")]
        public ActionResult<int> AddNewExpense(ExpenseDTO Expense)
        {
            if (Expense == null)
            {
                return BadRequest("Somthing Error Accured");
            }
            ExpenseData.AddNewExpense(Expense);

            //return CreatedAtRoute("GetExpense", Expense, Expense);
            return Ok("New Expense Add Successfully");
        }

        [HttpDelete("DeleteExpense{id}")]
        public ActionResult<int> Delete(int id)
        {
            int Result = ExpenseData.Delete(id);
            if (Result == 0)
            {
                return BadRequest("There Are An Error");

            }
            return Ok("Expense Deleted Successfully");
        }
        [HttpPut("UpdateExpense")]
        public ActionResult<ExpenseDTO> UpdateExpense([FromBody] ExpenseDTO UpdatedExpense)
        {
            var Expense = ExpenseData.Find(UpdatedExpense.ExpenseID);
            if (Expense == null)
            {
                return NotFound("There is No Expense here");
            }
            Expense.ExpenseID = UpdatedExpense.ExpenseID;
            Expense.ExpenseType = UpdatedExpense.ExpenseType;
            Expense.Amount = UpdatedExpense.Amount;
            Expense.ExpenseDate = UpdatedExpense.ExpenseDate;

            Expense.Notes = UpdatedExpense.Notes;
            Expense.OrderID = UpdatedExpense.OrderID;
            Expense.PersonID = UpdatedExpense.PersonID;
            Expense.EmployeeID = UpdatedExpense.EmployeeID;
            Expense.CustomerID = UpdatedExpense.CustomerID;
            Expense.DriverID = UpdatedExpense.DriverID;
            int Result = ExpenseData.Update(Expense);
            return Ok(Expense);

        }
    }
}