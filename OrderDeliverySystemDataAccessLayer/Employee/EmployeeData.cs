using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Employee
{

    public class EmployeeDTO
    {
        public EmployeeDTO(int PersonID, int EmployeeID, string UserName, string Status, string PasswordHash, bool IsActive,
        string? CreatedAt = null, string? UpdatedAt = null, bool? IsDeleted = null)
        {
            this.EmployeeID = EmployeeID;
            this.UserName = UserName;
            this.Status = Status;
            this.PasswordHash = PasswordHash;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.IsDeleted = IsDeleted;
            this.PersonID = PersonID;
        }
        public int PersonID { get; set; }
        public int EmployeeID { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class EmployeeData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static EmployeeDTO Get(int EmployeeID)
        {
            EmployeeDTO Employee = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Employees_GetEmployeeByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Employee = new EmployeeDTO
                           (
                           reader.GetInt32(reader.GetOrdinal("PersonID")),
                           reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                           reader.GetString(reader.GetOrdinal("UserName")),
                           reader.GetString(reader.GetOrdinal("Status")),
                           reader.GetString(reader.GetOrdinal("PasswordHash")),
                           reader.GetBoolean(reader.GetOrdinal("IsActive")),
                           reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                           reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                           reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                           );
                        }
                        return Employee;
                    }
                }
            }
        }
        public static List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> EmployeesList = new List<EmployeeDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Employees_GetAllEmployees", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeDTO Employee = new EmployeeDTO
                            (
                           reader.GetInt32(reader.GetOrdinal("PersonID")),
                           reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                           reader.GetString(reader.GetOrdinal("UserName")),
                           reader.GetString(reader.GetOrdinal("Status")),
                           reader.GetString(reader.GetOrdinal("PasswordHash")),
                           reader.GetBoolean(reader.GetOrdinal("IsActive")),
                           reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                           reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                           reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                            );
                            EmployeesList.Add(Employee);
                        }
                    }

                }
            }
            return EmployeesList;
        }
        public static int Delete(int EmployeeID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Employees_DeleteEmployeeId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);
                    conn.Open();
                    int RowsAcount = cmd.ExecuteNonQuery();
                    return RowsAcount;
                }
            }
        }
        public static int Update(EmployeeDTO UpdatedEmployee)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Employees_UpdateEmployeeByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("EmployeeID", UpdatedEmployee.EmployeeID);
                    cmd.Parameters.AddWithValue("UpadtedPasswordHash", UpdatedEmployee.PasswordHash);
                    cmd.Parameters.AddWithValue("UpdatedUserName", UpdatedEmployee.UserName);
                    cmd.Parameters.AddWithValue("UpdatedStatus", UpdatedEmployee.Status);
                    cmd.Parameters.AddWithValue("UpdatedIsActive", UpdatedEmployee.IsActive);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                    return Rowcount;
                }
            }
        }

        public static int AddNew(EmployeeDTO NewEmployee)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Employees_AddEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PersonID", NewEmployee.PersonID);
                    cmd.Parameters.AddWithValue("PasswordHash", NewEmployee.PasswordHash);
                    cmd.Parameters.AddWithValue("UserName", NewEmployee.UserName);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                    return Rowcount;
                }
            }
        }

    }
}
