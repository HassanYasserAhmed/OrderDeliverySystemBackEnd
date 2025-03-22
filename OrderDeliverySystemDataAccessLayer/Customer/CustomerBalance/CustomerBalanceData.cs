using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Customer.CustomerBalance
{
    public class CustomerBalanceDTO
    {

        public CustomerBalanceDTO(int CustomerID, decimal Balance, bool IsLocked, bool IsDeleted,
                                  int? BalanceID, decimal? PreviosBalance = null, string? CreatedAt = null,
                                  string? LastUpdated = null)
        {
            this.CustomerID = CustomerID;
            this.Balance = Balance;
            this.IsLocked = IsLocked;
            this.IsDeleted = IsDeleted;
            this.BalanceID = BalanceID;
            this.PreviosBalance = PreviosBalance;
            this.CreatedAt = CreatedAt;
            this.LastUpdated = LastUpdated;
        }
        public CustomerBalanceDTO() { }
        public int? BalanceID { get; set; }
        public int CustomerID { get; set; }
        public decimal Balance { get; set; }
        public decimal? PreviosBalance { get; set; }
        public string? CreatedAt { get; set; }
        public string? LastUpdated { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeleted { get; set; }
    }





    public class CustomerBalanceData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static  CustomerBalanceDTO Get(int CustomerID)
        {
            CustomerBalanceDTO CustomerBalance = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_GetBalance", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure ;
                    cmd.Parameters.AddWithValue("CustomerID", CustomerID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            CustomerBalance = new CustomerBalanceDTO
                                (
                                reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                reader.GetDecimal(reader.GetOrdinal("Balance")),
                                reader.GetBoolean(reader.GetOrdinal("IsLocked")),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted")),

                                reader.GetInt32(reader.GetOrdinal("BalanceID")),
                                reader.GetDecimal(reader.GetOrdinal("PreviousBalance")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                                reader.GetDateTime(reader.GetOrdinal("LastUpdated")).ToString("yyyy-MM-dd HH-mm-ss")
                                );
                        }
                    return CustomerBalance;
                    }

                }
            }
        }
       public static int CreditDebitBalance(decimal Amount,int CustomerID)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_CreditDebitBalance", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Amount",Amount);
                    cmd.Parameters.AddWithValue("CustomerID",CustomerID);
                    conn.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();
                        return RowsAffected;
                       

                }
            }
        }
    }
    
}
