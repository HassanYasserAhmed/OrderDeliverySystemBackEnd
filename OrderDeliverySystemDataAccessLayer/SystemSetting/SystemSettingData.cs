using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OrderDeliverySystemBusinessLayer.salary;

namespace OrderDeliverySystemDataAccessLayer.SystemSetting
{
    public class SystemSettingDTO
    {
        public SystemSettingDTO(int SystemSettinID, string SettingName,
                                decimal SettingValue, string LastUpdate,
                                bool IsDeleted)
        { 
            this.SystemSettingID = SystemSettinID;
            this.SettingName = SettingName;
            this.SettingValue = SettingValue;
            this.LastUpdate = LastUpdate;
            this.IsDeleted = IsDeleted;
        }
        public SystemSettingDTO() { }
        public int SystemSettingID { get; set; }
        public string SettingName { get; set; }
        public decimal SettingValue { get; set; }
        public string LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
  
    }


    public class SystemSettinData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static SystemSettingDTO Find(int SystemSettingId)
        {
            SystemSettingDTO Salary = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SystemSettings_GetSystemSettingByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("SystemSettingID", SystemSettingId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Salary = new SystemSettingDTO(
                                reader.GetInt32(reader.GetOrdinal("SystemSettingID")),
                                reader.GetString(reader.GetOrdinal("SettingName")),
                                reader.GetDecimal(reader.GetOrdinal("SettingValue")),
                                reader.GetDateTime(reader.GetOrdinal("LastUpdate")).ToString("yyyy-MM-dd HH-mm-ss"),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                            );
                        }
                    }
                }
            }

            return Salary;
        }

        public static List<SystemSettingDTO> FindAll()
        {
            List<SystemSettingDTO> SalariesList = new List<SystemSettingDTO>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SP_SystemSettings_GetAllSystemSettings", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            SystemSettingDTO SalaryItem = new SystemSettingDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("SystemSettingID")),
                                reader.GetString(reader.GetOrdinal("SettingName")),
                                reader.GetDecimal(reader.GetOrdinal("SettingValue")),
                                reader.GetDateTime(reader.GetOrdinal("LastUpdate")).ToString("yyyy-MM-dd HH-mm-ss"),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted"))

                             );

                            SalariesList.Add(SalaryItem);

                        }
                        return SalariesList;

                    }
                }
            }
        }

        public static int Delete(int SystemSettingID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_SystemSettings_DeleteSystemSettingByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("SystemSettingID", SystemSettingID);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }

        public static int Updated(SystemSettingDTO UpdatedSystemSetting)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SystemSettings_UpdateSystemSettingByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("SystemSettingID", UpdatedSystemSetting.SystemSettingID);
                    cmd.Parameters.AddWithValue("SettingName", UpdatedSystemSetting.SettingName);
                    cmd.Parameters.AddWithValue("SettingValue", UpdatedSystemSetting.SettingValue);

                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    return RowsAffected;
                }
            }
        }

        public static int AddNew(SystemSettingDTO NewSetting)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SystemSettings_AddNewSetting", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("SettingName", NewSetting.SettingName);
                    cmd.Parameters.AddWithValue("SettingValue", NewSetting.SettingValue);


                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;

                }
            }
        }
    }
}