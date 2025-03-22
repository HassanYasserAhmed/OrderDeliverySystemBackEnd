using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemBusinessLayer.salary
{
    public class SalaryDTO
    {
        public SalaryDTO() { }
        public SalaryDTO(int SalaryID, decimal BaseSalary, decimal Bonus, decimal Deductions, int SalaryMonth, decimal NetSalary,
           string PaymentsStatus, string PaymentDate, int PersonID, bool IsDeleted)
        {
            this.SalaryID = SalaryID;
            this.BaseSalary = BaseSalary;
            this.Bonus = Bonus;
            this.Deductions = Deductions;
            this.SalaryMonth = SalaryMonth;
            this.NetSalary = NetSalary;
            this.PaymentStatus = PaymentsStatus;
            this.PaymentDate = PaymentDate;
            this.PersonID = PersonID;
            this.IsDeleted = IsDeleted;
          
        }
        public int SalaryID { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public int SalaryMonth { get; set; }
        public decimal NetSalary { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentDate { get; set; }
        public int PersonID { get; set; }
        public bool IsDeleted { get; set; }


    }
    public class SalaryData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static SalaryDTO Find(int PersonID)
        {
            SalaryDTO Salary = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Salaries_GetLastSalaryByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PersonID", PersonID);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            Salary = new SalaryDTO(
                          reader.GetInt32(reader.GetOrdinal("SalaryID")),
                                reader.GetDecimal(reader.GetOrdinal("BaseSalary")),
                                reader.GetDecimal(reader.GetOrdinal("Bonus")),
                                reader.GetDecimal(reader.GetOrdinal("Deductions")),
                                reader.GetInt32(reader.GetOrdinal("SalaryMonth")),

                                reader.GetDecimal(reader.GetOrdinal("NetSalary")),
                                reader.GetString(reader.GetOrdinal("PaymentStatus")),
                                reader.GetDateTime(reader.GetOrdinal("PaymentDate")).ToString("yyyy-MM-dd HH-mm-SS"),
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                            );
                        }
                    }
                }
            }

            return Salary;
        }

        public static List<SalaryDTO> FindAll(int PersonID)
        {
            List<SalaryDTO> SalariesList = new List<SalaryDTO>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SP_Salaries_GetAllSalariesByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PersonID",PersonID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            SalaryDTO SalaryItem = new SalaryDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("SalaryID")),
                                reader.GetDecimal(reader.GetOrdinal("BaseSalary")),
                                reader.GetDecimal(reader.GetOrdinal("Bonus")),
                                reader.GetDecimal(reader.GetOrdinal("Deductions")),
                                reader.GetInt32(reader.GetOrdinal("SalaryMonth")),

                                reader.GetDecimal(reader.GetOrdinal("NetSalary")),
                                reader.GetString(reader.GetOrdinal("PaymentStatus")),
                                reader.GetDateTime(reader.GetOrdinal("PaymentDate")).ToString("yyyy-MM-dd HH-mm-SS"),
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                reader.GetBoolean(reader.GetOrdinal("IsDeleted"))

                             );

                            SalariesList.Add(SalaryItem);

                        }
                        return SalariesList;

                    }
                }
            }
        }

        public static int Delete(int PersonID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_Salaries_DeleteSalary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PersonID", PersonID);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }

        public static int Updated(SalaryDTO UpdatedSalary)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Salaries_UpdateSalary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UBaseSalary", UpdatedSalary.BaseSalary);
                    cmd.Parameters.AddWithValue("UBonus", UpdatedSalary.Bonus);
                    cmd.Parameters.AddWithValue("UDeductions", UpdatedSalary.Deductions);
                    cmd.Parameters.AddWithValue("UPaymentsStatus", UpdatedSalary.PaymentStatus);
                    cmd.Parameters.AddWithValue("Person_ID", UpdatedSalary.PersonID);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    return RowsAffected;
                }
            }
        }

        public static int AddNew(SalaryDTO NewSalary)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Salaries_AddNewSalary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("PersonID", NewSalary.PersonID);
                    cmd.Parameters.AddWithValue("BaseSalary", NewSalary.BaseSalary);
                    cmd.Parameters.AddWithValue("Bonus", NewSalary.Bonus);
                    cmd.Parameters.AddWithValue("Deductions", NewSalary.Deductions);
                    cmd.Parameters.AddWithValue("PaymentsStatus", NewSalary.PaymentStatus);


                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;

                }
            }
        }
    }
}