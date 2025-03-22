using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Customer.CustomerTransactions
{
    public class CustomerTranactionsDTO
    {
        public CustomerTranactionsDTO(int CustomerTransActionsId,decimal Amount,string TransactionType,
                                    string TransactionDate,string Notes,int CustomerId,bool IsDeleted,string PaymentMethod) 
        { 
            this.CustomerTransActionsID = CustomerTransActionsId;
            this.Amount = Amount;
            this.TransactionType = TransactionType;
            this.TransactionDate = TransactionDate;
            this.Notes = Notes;
            this.CustomerId = CustomerId;
            this.IsDeleted = IsDeleted;
            this.PaymentMethod = PaymentMethod;
        }
        public int CustomerTransActionsID { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDate { get; set; }
        public string Notes { get; set; }
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }
        public string PaymentMethod { get; set; }

    }
    public class CustomerTransActionsData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static List<CustomerTranactionsDTO>  FindAll(int CustomerId)
        {
            List<CustomerTranactionsDTO> CustomerTransActionsList  = new List<CustomerTranactionsDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_GetAllTransactions",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", CustomerId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var CustomerTransaction = new CustomerTranactionsDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("CustomerTransactionID")),
                                reader.GetDecimal(reader.GetOrdinal("Amount")),
                                reader.GetString(reader.GetOrdinal("TransactionType")),
                                reader.GetString(reader.GetOrdinal("TransactionDate")),
                                reader.GetString(reader.GetOrdinal("Notes")),
                                reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                                reader.GetString(reader.GetOrdinal("PaymentMethod"))
                            );
                            CustomerTransActionsList.Add(CustomerTransaction);
                        }
                       
                    }
                }
            }
         return CustomerTransActionsList;    
        }
        public static int AddNew(CustomerTranactionsDTO NewcustomerTransaction)
        {
          
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_AddCustomerTransaction",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("CustomerId", NewcustomerTransaction.CustomerId);
                    cmd.Parameters.AddWithValue("TransactionType", NewcustomerTransaction.TransactionType);
                    cmd.Parameters.AddWithValue("Notes", NewcustomerTransaction.Notes);
                    cmd.Parameters.AddWithValue("Amount", NewcustomerTransaction.Amount);
                    cmd.Parameters.AddWithValue("PaymentMethod", NewcustomerTransaction.PaymentMethod);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                };

               
            }
        }
    }
}
