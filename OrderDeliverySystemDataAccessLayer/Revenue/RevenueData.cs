using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using RevenueDeliverySystemDataAccessLayer.Revenue;

namespace RevenueDeliverySystemDataAccessLayer.Revenue
{
    public class RevenueDTO
    {
        public RevenueDTO(int RevenueID, decimal Amount, string RevenueDate, string Notes,
                         int OrderID, int CustomerID, int EmployeeID, int AdminID, bool IsDeleted)
        {
            this.RevenueID = RevenueID;
            this.Amount = Amount;
            this.RevenueDate = RevenueDate;
            this.Notes = Notes;
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.EmployeeID = EmployeeID;
            this.AdminID = AdminID;
            this.IsDeleted = IsDeleted;
        }
        public RevenueDTO() { }
        public int RevenueID { get; set; }
        public decimal Amount { get; set; }
        public string RevenueDate { get; set; }
        public string Notes { get; set; }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int AdminID { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class RevenueData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static RevenueDTO Find(int RevenueID)
        {
            RevenueDTO Revenue = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Revenues_GetRevenueByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", RevenueID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Revenue = new RevenueDTO(
                             reader.GetInt32(reader.GetOrdinal("RevenueID")),
                             reader.GetDecimal(reader.GetOrdinal("Amount")),
                             reader.GetDateTime(reader.GetOrdinal("RevenueDate")).ToString("yyyy-MM-dd HH-mm-ss"),
                             reader.GetString(reader.GetOrdinal("Notes")),
                             reader.GetInt32(reader.GetOrdinal("OrderID")),

                             reader.GetInt32(reader.GetOrdinal("CustomerID")),
                             reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                             reader.GetInt32(reader.GetOrdinal("AdminID")),
                             reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                            );
                        }


                    }

                }
            }

            return Revenue;
        }

        public static List<RevenueDTO> FindAll()
        {
            List<RevenueDTO> RevenueList = new List<RevenueDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SP_Revenues_GetAllRevenues", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var Revenue = new RevenueDTO
                            (
                             reader.GetInt32(reader.GetOrdinal("RevenueID")),
                             reader.GetDecimal(reader.GetOrdinal("Amount")),
                             reader.GetDateTime(reader.GetOrdinal("RevenueDate")).ToString("yyyy-MM-dd HH-mm-ss"),
                             reader.GetString(reader.GetOrdinal("Notes")),
                             reader.GetInt32(reader.GetOrdinal("OrderID")),

                             reader.GetInt32(reader.GetOrdinal("CustomerID")),
                             reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                             reader.GetInt32(reader.GetOrdinal("AdminID")),
                             reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                             );

                            RevenueList.Add(Revenue);

                        }
                        return RevenueList;

                    }
                }
            }
        }

        public static int Delete(int RevenueID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_Revenues_DeleteRevenue", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", RevenueID);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }

        public static int Update(RevenueDTO UpdatedRevenue)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Revenues_UpdateRevenue", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", UpdatedRevenue.RevenueID);
                    cmd.Parameters.AddWithValue("UAmount", UpdatedRevenue.Amount);
                    cmd.Parameters.AddWithValue("UNotes", UpdatedRevenue.Notes);
                    cmd.Parameters.AddWithValue("UOrderID", UpdatedRevenue.OrderID);
                    cmd.Parameters.AddWithValue("UCustomerID", UpdatedRevenue.CustomerID);
                    cmd.Parameters.AddWithValue("UEmployeeID", UpdatedRevenue.EmployeeID);
                    cmd.Parameters.AddWithValue("UAdminID", UpdatedRevenue.AdminID);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    return RowsAffected;
                }
            }
        }

        public static int Add(RevenueDTO NewRevenue)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Revenues_AddRevenue", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("Amount", NewRevenue.Amount);
                    cmd.Parameters.AddWithValue("Notes", NewRevenue.Notes);
                    cmd.Parameters.AddWithValue("OrderID", NewRevenue.OrderID);
                    cmd.Parameters.AddWithValue("CustomerID", NewRevenue.CustomerID);
                    cmd.Parameters.AddWithValue("EmployeeID", NewRevenue.EmployeeID);
                    cmd.Parameters.AddWithValue("AdminID", NewRevenue.AdminID);
                    

                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;

                }
            }
        }
    }
}
