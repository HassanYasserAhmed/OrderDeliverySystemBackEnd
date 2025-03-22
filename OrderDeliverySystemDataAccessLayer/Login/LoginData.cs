using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Login
{
    public class LoginData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        //public static string LoginByUserNameAndPassword(string UserName, string Password)
        //{
        //    string Role = null;
        //    using (SqlConnection conn = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SP_Login_LoginByUserNameAndPassword", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            conn.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    Role = reader.GetString(reader.GetOrdinal("Role"));
        //                }
        //                SqlParameter outputParam = new SqlParameter("Role", SqlDbType.Int)
        //                {
        //                    Direction = ParameterDirection.Output
        //                };
        //                cmd.Parameters.Add(outputParam);

        //                // تنفيذ الإجراء المخزن
        //                cmd.ExecuteNonQuery();

        //                // استرجاع PersonID
        //                string PersonID = (string)outputParam.Value;

        //                return PersonID; // 

        //            }
        //        }
        //    }
        //}

        public static string LoginByUserNameAndPassword(string UserName, string Password)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Login_LoginByUserNameAndPassword", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserName", UserName);
                    cmd.Parameters.AddWithValue("PasswordHash", Password);
                    conn.Open();
                       
                    



                        SqlParameter outputParam = new SqlParameter("Role", SqlDbType.NVarChar,50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);
                        cmd.ExecuteNonQuery();
                        string Role = (string)outputParam.Value;
                        return Role; // 
                }
            }
        }
    }
}