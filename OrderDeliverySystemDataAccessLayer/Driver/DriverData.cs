using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Driver
{

    public class DriverDTO
    {
        public DriverDTO(int PersonID,int DriverID, string UserName, string VehicalType,
        string VehicalLicense, string Status, string PasswordHash, bool IsActive,
        string? CreatedAt = null, string? UpdatedAt = null, bool? IsDeleted=null)
        {
            this.DriverID = DriverID;
            this.UserName = UserName;
            this.VehicalType = VehicalType;
            this.VehicalLicense = VehicalLicense;
            this.Status = Status;
            this.PasswordHash = PasswordHash;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.IsDeleted = IsDeleted;
            this.PersonID = PersonID;
        }
        public int PersonID { get; set; }
        public int DriverID { get; set; }
        public string UserName { get; set; }
        public string VehicalType { get; set; }
        public string VehicalLicense { get; set; }
        public string Status { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class DriverData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static DriverDTO Get(int DriverID)
        {
            DriverDTO Driver = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_GetDriverByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DriverID", DriverID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Driver = new DriverDTO
                           (
                           reader.GetInt32(reader.GetOrdinal("PersonID")),
                           reader.GetInt32(reader.GetOrdinal("DriverID")),
                           reader.GetString(reader.GetOrdinal("UserName")),
                           reader.GetString(reader.GetOrdinal("VehicaleType")),
                           reader.GetString(reader.GetOrdinal("VehicaleLicense")),
                           reader.GetString(reader.GetOrdinal("Status")),
                           reader.GetString(reader.GetOrdinal("PasswordHash")),
                           reader.GetBoolean(reader.GetOrdinal("IsActive")),
                           reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                           reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                           reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                           );
                        }
                        return Driver;
                    }
                }
            }
        }
        public static List<DriverDTO> GetAll()
        {
            List<DriverDTO> DriversList = new List<DriverDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_GetAllDrivers", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DriverDTO Driver = new DriverDTO
                            (
                           reader.GetInt32(reader.GetOrdinal("PersonID")),
                           reader.GetInt32(reader.GetOrdinal("DriverID")),
                           reader.GetString(reader.GetOrdinal("UserName")),
                           reader.GetString(reader.GetOrdinal("VehicaleType")),
                           reader.GetString(reader.GetOrdinal("VehicaleLicense")),
                           reader.GetString(reader.GetOrdinal("Status")),
                           reader.GetString(reader.GetOrdinal("PasswordHash")),
                           reader.GetBoolean(reader.GetOrdinal("IsActive")),
                           reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                           reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                           reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                            );
                            DriversList.Add(Driver);
                        }
                    }

                }
            }
            return DriversList;
        }
        public static int Delete(int DriverID)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_DeleteDriver", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DriverID", DriverID);
                    conn.Open();
                    int RowsAcount = cmd.ExecuteNonQuery();
                  return RowsAcount;
                }
            }
        }
        public static int Update(DriverDTO UpdatedDriver)
        {
            DriverDTO Driver = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_UpdateDriver", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DriverID", UpdatedDriver.DriverID);
                    cmd.Parameters.AddWithValue("UpadtedPasswordHash", UpdatedDriver.PasswordHash);
                    cmd.Parameters.AddWithValue("UpdatedUserName", UpdatedDriver.UserName);
                    cmd.Parameters.AddWithValue("UpdatedVehicaleLicense", UpdatedDriver.VehicalLicense);
                    cmd.Parameters.AddWithValue("UpdatedVehicaleType", UpdatedDriver.VehicalType);
                    cmd.Parameters.AddWithValue("UpdatedStatus", UpdatedDriver.Status);
                    cmd.Parameters.AddWithValue("UpdatedIsActive", UpdatedDriver.IsActive);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                return Rowcount;
                }
            }
        }

        public static int AddNew(DriverDTO NewDriver)
        {
            DriverDTO Driver = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_AddNewDriver", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PersonID", NewDriver.PersonID);
                    cmd.Parameters.AddWithValue("PasswordHash", NewDriver.PasswordHash);
                    cmd.Parameters.AddWithValue("UserName", NewDriver.UserName);
                    cmd.Parameters.AddWithValue("VehicaleLicense", NewDriver.VehicalLicense);
                    cmd.Parameters.AddWithValue("VehicaleType", NewDriver.VehicalType);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                    return Rowcount;
                }
            }
        }

    }
}
