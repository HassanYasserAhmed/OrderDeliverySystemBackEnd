using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemBusinessLayer.Person;
using OrderDeliverySystemDataAccessLayer.Expense;
using OrderDeliverySystemDataAccessLayer.People;

namespace OrderDeliverySystemBusinessLayer.Expense
{
    public class ExpenseService
    {
        public ExpenseDTO EDTO => new ExpenseDTO(ExpenseID, ExpenseType, Amount, 
                                                ExpenseDate, Notes, OrderID,
                                                EmployeeID, CustomerID, DriverID,
                                                IsDeleted, AdminID, PersonID);
        public ExpenseService(ExpenseDTO Expense)
        {
            this.ExpenseID = Expense.ExpenseID;
            this.ExpenseType = Expense.ExpenseType;
            this.Amount = Expense.Amount;
            this.ExpenseDate = Expense.ExpenseDate;
            this.Notes = Expense.Notes;
            this.OrderID = Expense.OrderID;
            this.PersonID = Expense.PersonID;
            this.EmployeeID = Expense.EmployeeID;
            this.CustomerID = Expense.CustomerID;
            this.DriverID = Expense.DriverID;
            this.IsDeleted = Expense.IsDeleted;
            this.AdminID = Expense.AdminID;
            this.PersonID = Expense.PersonID;
        }
        public ExpenseService() { }
        public int ExpenseID { get; set; }
        public string ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public string ExpenseDate { get; set; }
        public string Notes { get; set; }

        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public int DriverID { get; set; }

        public bool IsDeleted { get; set; }
        public int AdminID { get; set; }
        public int PersonID { get; set; }

        public static ExpenseService Find(int expenseID)
        {
            return new ExpenseService(ExpenseData.Find(expenseID));
        }

        //public static List<ExpenseService> FindAll()
        //{
        //    var ExpensesList = ExpenseData.FindAll() ?? new List<ExpenseDTO>();
        //    return ExpensesList.Select(Expense => new ExpenseService(Expense)).ToList();
        //}
        public static List<ExpenseService> FindAll()
        {
            var expensesList = ExpenseData.FindAll();
            if (expensesList == null || !expensesList.Any())
            {
                return new List<ExpenseService>();
            }
            return expensesList.Select(expense => new ExpenseService(expense)).ToList();
        }

        public static int DeletePerson(int id)
        {
            return ExpenseData.Delete(id);
        }

        public static int UpdatePerson(ExpenseService personService)
        {
            if (personService == null)
                throw new ArgumentNullException(nameof(personService));
            
            var ExpenseDTO = personService.EDTO;
            return ExpenseData.Update(ExpenseDTO);
        }

        public static int AddNewExpense(ExpenseDTO NewExpense)
        {
            return ExpenseData.AddNewExpense(NewExpense);
        }

    }
}
