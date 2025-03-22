using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.DriverRating
{
    public class DriverRatingDTO
    {
        public DriverRatingDTO( int RatingID,int Rating, string Review,
        string RatingDate, int OrderID,
         bool IsDeleted,int DriverID)
        {
            this.RatingID = RatingID;
            this.Rating = Rating;
            this.Review = Review;
            this.RatingDate = RatingDate;

            this.OrderID = OrderID;
            this.IsDeleted = IsDeleted;
            this.DriverID = DriverID;
        }
        public int RatingID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public string RatingDate { get; set; }
        public int OrderID { get; set; }
        public bool IsDeleted { get; set; }
        public int DriverID { get; set; }

    }
    public class DriverRatingData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static DriverRatingDTO Get(int DriverRatingID)
        {
            DriverRatingDTO DriverRating = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_GetRatingByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("OrderID", DriverRatingID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DriverRating = new DriverRatingDTO
                           (
                           reader.GetInt32(reader.GetOrdinal("RatingID")),
                           reader.GetInt32(reader.GetOrdinal("Rating")),
                           reader.GetString(reader.GetOrdinal("Review")),
                           reader.GetDateTime(reader.GetOrdinal("RatingDate")).ToString("yyyy-MM-dd HH-mm-ss"),

                           reader.GetInt32(reader.GetOrdinal("OrderID")),
                           reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                           reader.GetInt32(reader.GetOrdinal("DriverID"))
                           );
                        }
                        return DriverRating;
                    }
                }
            }
        }
        public static List<DriverRatingDTO> GetAll()
        {
            List<DriverRatingDTO> DriverRatingsList = new List<DriverRatingDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_GetAllDriverRatings", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DriverRatingDTO DriverRating = new DriverRatingDTO
                            (
                           reader.GetInt32(reader.GetOrdinal("RatingID")),
                           reader.GetInt32(reader.GetOrdinal("Rating")),
                           reader.GetString(reader.GetOrdinal("Review")),
                           reader.GetDateTime(reader.GetOrdinal("RatingDate")).ToString("yyyy-MM-dd HH-mm-ss"),

                           reader.GetInt32(reader.GetOrdinal("OrderID")),
                           reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                           reader.GetInt32(reader.GetOrdinal("DriverID"))
                            );
                            DriverRatingsList.Add(DriverRating);
                        }
                    }

                }
            }
            return DriverRatingsList;
        }
        public static int Delete(int OrderID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_DeleteRating", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("OrderID", OrderID);
                    conn.Open();
                    int RowsAcount = cmd.ExecuteNonQuery();
                    return RowsAcount;
                }
            }
        }
        public static int Update(DriverRatingDTO UpdatedDriverRating)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_UpdateRating", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Rating", UpdatedDriverRating.Rating);
                    cmd.Parameters.AddWithValue("Review", UpdatedDriverRating.Review);
                    cmd.Parameters.AddWithValue("DriverID", UpdatedDriverRating.DriverID);
                    cmd.Parameters.AddWithValue("OrderID", UpdatedDriverRating.OrderID);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                    return Rowcount;
                }
            }
        }

        public static int AddNew(DriverRatingDTO NewDriverRating)
        {
            DriverRatingDTO DriverRating = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_DriverRatings_AddNewDriverRating", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Rating", NewDriverRating.Rating);
                    cmd.Parameters.AddWithValue("Review", NewDriverRating.Review);
                    cmd.Parameters.AddWithValue("RatingDate", NewDriverRating.RatingDate);
                    cmd.Parameters.AddWithValue("DriverID", NewDriverRating.DriverID);
                    cmd.Parameters.AddWithValue("OrderID", NewDriverRating.OrderID);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                    return Rowcount;
                }
            }
        }

    }
}
