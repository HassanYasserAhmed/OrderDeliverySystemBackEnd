using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OrderDeliverySystemDataAccessLayer.People;
namespace OrderDeliverySystemDataAccessLayer.Admin
{
    public class AdminDTO
    {
        public AdminDTO(int AdminID,int PersonID, string UserName, string PasswordHash)
        {
            this.AdminID = AdminID;
            this.UserName = UserName;
            this.PasswordHash = PasswordHash;
            this.PersonID = PersonID;
        }

     
        public AdminDTO() { }

        //Admin Data
        public int AdminID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }


    }

    public class AdminData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static AdminDTO Find()
        {
            AdminDTO Admin = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Admins_GetAdmin", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Admin = new AdminDTO
                                (
                                reader.GetInt32(reader.GetOrdinal("AdminID")),
                                reader.GetInt32(reader.GetOrdinal("PersonId")),
                                reader.GetString(reader.GetOrdinal("UserName")),
                                reader.GetString(reader.GetOrdinal("PasswordHash"))

                                );
                        }

                    }
                }

            }
            return Admin;
        }

        public static int Update(AdminDTO Admin)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Admins_UpdateAdmin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("UpdatedAdminUserName", Admin.UserName);
                    cmd.Parameters.AddWithValue("UpdatedAdminPasswordHash", Admin.PasswordHash);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }
    }
}
