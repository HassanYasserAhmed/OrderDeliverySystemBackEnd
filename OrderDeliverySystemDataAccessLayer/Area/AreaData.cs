using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Area
{
    public class AreaDTO
    {
        public AreaDTO(int AreaID, string AreaName, string Governerate,bool IsActive,
                       decimal DeliveryFee,string? CreatedAt = null,
                       string? UpdatedAt = null, bool? IsDeleted = null)
        {
            this.AreaID = AreaID;
            this.AreaName = AreaName;
            this.Governerate = Governerate;
            this.IsActive = IsActive;

            this.DeliveryFee = DeliveryFee;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
           this.IsDeleted = IsDeleted;
        }
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string Governerate { get; set; }
        public bool IsActive { get; set; }

        public decimal DeliveryFee { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class AreaData
    {

        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static AreaDTO Find(int Id)
        {
            AreaDTO Area = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Areas_GetAreaByID", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("AreaID", Id);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Area = new AreaDTO
                                (
                                reader.GetInt32(reader.GetOrdinal("AreaID")),
                                reader.GetString(reader.GetOrdinal("AreaName")),
                                reader.GetString(reader.GetOrdinal("Governerate")),
                                reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                reader.GetDecimal(reader.GetOrdinal("DeliveryFee")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH:mm:ss"),
                                reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH-MM-SS"),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                                );
                        }
                    }
                }
            }
            return Area;
        }

        public static List<AreaDTO> FindAll()
        {
            List<AreaDTO> Areas = new List<AreaDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Areas_GetAllAreas", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Area = new AreaDTO
                                  (
                                  reader.GetInt32(reader.GetOrdinal("AreaID")),
                                  reader.GetString(reader.GetOrdinal("AreaName")),
                                  reader.GetString(reader.GetOrdinal("Governerate")),
                                  reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                  reader.GetDecimal(reader.GetOrdinal("DeliveryFee")),
                                  reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH:mm:ss"),
                                  reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH-MM-SS"),
                                  reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                                  );
                            Areas.Add(Area);
                        }
                    }
                }
            }
            return Areas;
        }

        public static int Add(AreaDTO NewArea)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Areas_AddNewArea", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("AreaName", NewArea.AreaName);
                    cmd.Parameters.AddWithValue("Governerate", NewArea.Governerate);
                    cmd.Parameters.AddWithValue("DeliveryFee", NewArea.DeliveryFee);

                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }
        public static int Delete(int AreaId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Areas_DeleteAreaByID",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("AreaID", AreaId);
                    conn.Open ();
                    int RowsAffected = cmd.ExecuteNonQuery(); 
                    return RowsAffected;
                }
            }
        }
        public static int Update(AreaDTO NewArea)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Areas_UpdateAreaById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("AreaID", NewArea.AreaID);
                    cmd.Parameters.AddWithValue("NewAreaName",NewArea.AreaName);
                    cmd.Parameters.AddWithValue("NewDeliveryFee", NewArea.DeliveryFee);
                    cmd.Parameters.AddWithValue("NewGovernerateName", NewArea.Governerate);
                    cmd.Parameters.AddWithValue("NewIsActiveValue", NewArea.IsActive);
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }
    }
}