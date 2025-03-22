using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Expense
{
    public class ExpenseDTO
    {
        public ExpenseDTO(
                            int ExpenseID, string ExpenseType, decimal Amount, string ExpenseDate,
                            string Notes, int OrderID, int EmployeeID, int CustomerID,
                            int DriverID, bool IsDeleted, int AdminID,int PersonID
                        )
        {
            this.ExpenseID = ExpenseID;
            this.ExpenseType = ExpenseType;
            this.Amount = Amount;
            this.ExpenseDate = ExpenseDate;
            this.Notes = Notes;

            this.OrderID = OrderID;
            this.EmployeeID = EmployeeID;
            this.DriverID = DriverID;
            this.CustomerID = CustomerID;
            this.IsDeleted = IsDeleted;

            this.AdminID = AdminID;
            this.PersonID = PersonID;

        }
        public ExpenseDTO() { }
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
    }
    public class ExpenseData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static ExpenseDTO Find(int ExpenseID)
        {
            ExpenseDTO Expense = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_Expenses_GetExpenseById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ExpenseID", ExpenseID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Expense = new ExpenseDTO
                                (
                                reader.GetInt32(reader.GetOrdinal("ExpenseID")),
                                reader.GetString(reader.GetOrdinal("ExpenseType")),
                                reader.GetDecimal(reader.GetOrdinal("Amount")),
                                reader.GetDateTime(reader.GetOrdinal("ExpenseDate")).ToString("yyyy-MM-dd HH-mm-ss"),

                                reader.GetString(reader.GetOrdinal("Notes")),
                                reader.GetInt32(reader.GetOrdinal("OrderID")),
                                reader.GetInt32(reader.GetOrdinal("EmployeeID")),

                                reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                reader.GetInt32(reader.GetOrdinal("DriverID")),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                                reader.GetInt32(reader.GetOrdinal("AdminID")),
                                reader.GetInt32(reader.GetOrdinal("PersonID"))
                                );
                        }
                        return Expense;
                    }
                }
            }


        }



        public static List<ExpenseDTO> FindAll()
        {
            List<ExpenseDTO> ExpensesList = new List<ExpenseDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
            

                using (SqlCommand cmd = new SqlCommand("SP_Expenses_GetAllExpenses", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<ExpenseDTO> Expense = new List<ExpenseDTO>();
                        while (reader.Read())
                        {

                            var Expenses = new ExpenseDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("ExpenseID")),
                                reader.GetString(reader.GetOrdinal("ExpenseType")),
                                reader.GetDecimal(reader.GetOrdinal("Amount")),
                                reader.GetDateTime(reader.GetOrdinal("ExpenseDate")).ToString("yyyy-MM-dd HH-mm-ss"),

                                reader.GetString(reader.GetOrdinal("Notes")),
                                reader.GetInt32(reader.GetOrdinal("OrderID")),
                                reader.GetInt32(reader.GetOrdinal("EmployeeID")),

                                reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                reader.GetInt32(reader.GetOrdinal("DriverID")),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                                reader.GetInt32(reader.GetOrdinal("AdminID")),
                                reader.GetInt32(reader.GetOrdinal("PersonID"))
                             );

                            ExpensesList.Add(Expenses);

                        }
                    }
                }

            }
            return ExpensesList;

        }

        public static int Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_Expenses_DeleteExpensesByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ExpenseID", id);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }

        public static int Update(ExpenseDTO Expense)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Expenses_UpdateExpensesByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ExpenseID", Expense.ExpenseID);

                    cmd.Parameters.AddWithValue("UExpenseType", Expense.ExpenseType);
                    cmd.Parameters.AddWithValue("UAmount", Expense.Amount);
                    cmd.Parameters.AddWithValue("UNotes", Expense.Notes);
                    cmd.Parameters.AddWithValue("UOrderID", Expense.OrderID);
                    cmd.Parameters.AddWithValue("UEmployeeID", Expense.EmployeeID);
                    cmd.Parameters.AddWithValue("UCustomerID", Expense.CustomerID);
                    cmd.Parameters.AddWithValue("UDriverID", Expense.DriverID);
                    cmd.Parameters.AddWithValue("UPersonID", Expense.PersonID);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    return RowsAffected;
                }
            }
        }

        public static int AddNewExpense(ExpenseDTO NewExpense)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Expenses_AddNewExpense", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("ExpenseType", NewExpense.ExpenseType);
                    cmd.Parameters.AddWithValue("Amount", NewExpense.Amount);
                    cmd.Parameters.AddWithValue("Notes", NewExpense.ExpenseDate);
                    cmd.Parameters.AddWithValue("OrderID", NewExpense.OrderID);

                    cmd.Parameters.AddWithValue("EmployeeID", NewExpense.EmployeeID);
                    cmd.Parameters.AddWithValue("CustomerID", NewExpense.CustomerID);
                    cmd.Parameters.AddWithValue("DriverID", NewExpense.DriverID);
                    cmd.Parameters.AddWithValue("PersonID", NewExpense.PersonID);

                    cmd.Parameters.AddWithValue("AdminID", NewExpense.AdminID);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;

                }
            }
        }
    }
}

