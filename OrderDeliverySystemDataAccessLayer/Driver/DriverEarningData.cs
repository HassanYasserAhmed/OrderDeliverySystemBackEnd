using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OrderDeliverySystemDataAccessLayer.DriverRating;

namespace OrderDeliverySystemDataAccessLayer.Driver
{
    public class DriverEarningDTO
    {
        public DriverEarningDTO(int EarningID, decimal Amount,
        string EarningDate, int DriverID, bool IsDeleted,int OrderID)
        {
            this.EarningID = EarningID;
            this.Amount = Amount;
            this.EarningDate = EarningDate;

            this.DriverID = DriverID;
            this.IsDeleted = IsDeleted;
            this.OrderID = OrderID;
        }
        public DriverEarningDTO() { }
        public int EarningID { get; set; }
        public decimal Amount { get; set; }
        public string EarningDate { get; set; }
        public int DriverID { get; set; }
        public bool IsDeleted { get; set; }
        public int OrderID { get; set; }
    }
    public class DriverEarningData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static DriverEarningDTO Get(int DriverRatingID)
        {
            DriverEarningDTO DriverRating = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_GetDriverEarnigById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("OrderID", DriverRatingID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DriverRating = new DriverEarningDTO
                           (
                               reader.GetInt32(reader.GetOrdinal("EarningID")),
                               reader.GetDecimal(reader.GetOrdinal("Amount")),
                               reader.GetDateTime(reader.GetOrdinal("EarningDate")).ToString("yyyy-MM-dd HH-mm-ss"),
                                reader.GetInt32(reader.GetOrdinal("DriverID")),
                               reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                               reader.GetInt32(reader.GetOrdinal("OrderID"))

                           );
                        }
                        return DriverRating;
                    }
                }
            }
        }
        public static List<DriverEarningDTO> GetAll(int DriverID)
        {
            List<DriverEarningDTO> DriverRatingsList = new List<DriverEarningDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_GetAllEarnigsById", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DriverID", DriverID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DriverEarningDTO DriverRating = new DriverEarningDTO
                            (
                               reader.GetInt32(reader.GetOrdinal("EarningID")),
                               reader.GetDecimal(reader.GetOrdinal("Amount")),
                               reader.GetDateTime(reader.GetOrdinal("EarningDate")).ToString("yyyy-MM-dd HH-mm-ss"),
                                reader.GetInt32(reader.GetOrdinal("DriverID")),
                               reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                               reader.GetInt32(reader.GetOrdinal("OrderID"))
                            );
                            DriverRatingsList.Add(DriverRating);
                        }
                    }

                }
            }
            return DriverRatingsList;
        }
     
        public static int Update(DriverEarningDTO UpdatedDriverRating)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_UpdateEarning", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("DriverID", UpdatedDriverRating.DriverID);
                    cmd.Parameters.AddWithValue("UAmount", UpdatedDriverRating.Amount);
                    cmd.Parameters.AddWithValue("UDriverID", UpdatedDriverRating.DriverID);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                    return Rowcount;
                }
            }
        }

        public static int AddNew(DriverEarningDTO NewDriverRating)
        {
            DriverEarningDTO DriverRating = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_AddNewEarning", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Amount", NewDriverRating.Amount);
                    cmd.Parameters.AddWithValue("DriverID", NewDriverRating.DriverID);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                    return Rowcount;
                }
            }
        }

    }
}
