using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Customer
{
    public class CustomerDTO
    {
        public CustomerDTO(int CustomerID, int PersonID, string UserName,
            string PasswordHash, string Status, bool IsActive,
            string? DateJoined = null, string? LastUpdated = null, bool? IsDeleted = null)
        {
            this.CustomerID = CustomerID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.PasswordHash = PasswordHash;

            this.Status = Status;
            this.IsActive = IsActive;
            this.Datejoined = DateJoined;
            this.LastUpdated = LastUpdated;

            this.IsDeleted = IsDeleted;
        }
        public int CustomerID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string? Datejoined { get; set; }
        public string? LastUpdated { get; set; }

        public bool? IsDeleted { get; set; }

    }
    public class CustomerData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static int AddNew(CustomerDTO NewCustomer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_AddNewCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("PersonID", NewCustomer.PersonID);
                    cmd.Parameters.AddWithValue("CustomerUserName", NewCustomer.UserName);
                    cmd.Parameters.AddWithValue("CustomerPasswordHash", NewCustomer.PasswordHash);
                    SqlParameter OutputParam = new SqlParameter("@CustomerID",SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(OutputParam);
                    cmd.ExecuteNonQuery();
                    int CustomerID = (int)OutputParam.Value;
                    return CustomerID;
                }
            }
        }
        public static CustomerDTO Find(int ID)
        {
            CustomerDTO Customer = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_GetCustomerbyID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("CustomerID", ID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Customer = new CustomerDTO
                                (
                                reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                reader.GetString(reader.GetOrdinal("UserName")),
                                reader.GetString(reader.GetOrdinal("PasswordHash")),
                                reader.GetString(reader.GetOrdinal("Status")),
                                reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                reader.GetDateTime(reader.GetOrdinal("DateJoin")).ToString("yyyy-MM-dd HH:mm:ss"),
                                reader.GetDateTime(reader.GetOrdinal("LastUpdate")).ToString("yyyy-MM-dd HH:mm:ss"),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                               
                                );
                        }
                    }
                }
            }
        return Customer;
        }

        public static  List<CustomerDTO> FindAll()
        {
            List<CustomerDTO> CustomersList = new List<CustomerDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_GetAllCustomers",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var Customer = new CustomerDTO
                                (
                                reader.GetInt32(reader.GetOrdinal("CustomerID")),
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                reader.GetString(reader.GetOrdinal("UserName")),
                                reader.GetString(reader.GetOrdinal("PasswordHash")),
                                reader.GetString(reader.GetOrdinal("Status")),
                                reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                reader.GetDateTime(reader.GetOrdinal("DateJoin")).ToString("yyy-MM-dd HH-mm-ss"),
                                reader.GetDateTime(reader.GetOrdinal("LastUpdate")).ToString("yyyy-MM-dd HH-mm-ss"),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                                );
                            CustomersList.Add(Customer);
                        }
                    }

                }
            }
            return CustomersList;
        }

        public static int Delete (int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_DeleteCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("CustomerID", id);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }

        public static int Update(CustomerDTO UpdatedCustomer)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_UpdateCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("UpdatedUserName", UpdatedCustomer.UserName);
                    cmd.Parameters.AddWithValue("UpdatedPasswordHash", UpdatedCustomer.PasswordHash);
                    cmd.Parameters.AddWithValue("UpdatedStatus", UpdatedCustomer.Status);
                    cmd.Parameters.AddWithValue("UpdatedIsActive", UpdatedCustomer.IsActive);
                    cmd.Parameters.AddWithValue("CustomerID", UpdatedCustomer.CustomerID);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }
    }
}
