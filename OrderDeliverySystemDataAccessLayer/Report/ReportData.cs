using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ReportDeliverySystemDataAccessLayer.Report;

namespace ReportDeliverySystemDataAccessLayer.Report
{
    public class ReportDTO
    {
        public ReportDTO(int ReprotID, string ReportDate, int TotalOrders,
                        decimal Revenue, decimal Expenses, decimal NetProfit,
                        string CreatedAt, string UpdatedAT, bool IsDeleted)
        {
            this.ReportID = ReprotID;
            this.ReportDate = ReportDate;
            this.TotalOrders = TotalOrders;
            this.Revenue = Revenue;
            this.Expenses = Expenses;
            this.NetProfit = NetProfit;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAT;
            this.IsDeleted = IsDeleted;
        }
        public ReportDTO() { }
        public int ReportID { get; set; }
        public string ReportDate { get; set; }
        public int TotalOrders { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal NetProfit { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
        public class ReportData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static ReportDTO Find(int ReportID)
            {
                ReportDTO Report = null;

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Reports_GetReportById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("ReportID", ReportID);

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Report = new ReportDTO(
                                 reader.GetInt32(reader.GetOrdinal("ReportID")),
                                 reader.GetDateTime(reader.GetOrdinal("ReportDate")).ToString("yyyy-MM-dd HH-mm-ss"),
                                 reader.GetInt32(reader.GetOrdinal("TotalOrders")),
                                 reader.GetDecimal(reader.GetOrdinal("Revenue")),
                                 reader.GetDecimal(reader.GetOrdinal("Expenses")),

                                 reader.GetDecimal(reader.GetOrdinal("NetProfit")),
                                 reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                                 reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                                 reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                                );
                            }


                        }

                    }
                }

                return Report;
            }

            public static List<ReportDTO> FindAll()
            {
                List<ReportDTO> ReportsList = new List<ReportDTO>();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_Reports_GetAllReports", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                var Report = new ReportDTO
                                (
                                 reader.GetInt32(reader.GetOrdinal("ReportID")),
                                 reader.GetDateTime(reader.GetOrdinal("ReportDate")).ToString("yyyy-MM-dd HH-mm-ss"),
                                 reader.GetInt32(reader.GetOrdinal("TotalOrders")),
                                 reader.GetDecimal(reader.GetOrdinal("Revenue")),
                                 reader.GetDecimal(reader.GetOrdinal("Expenses")),

                                 reader.GetDecimal(reader.GetOrdinal("NetProfit")),
                                 reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                                 reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH-mm-ss"),
                                 reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                                 );

                                ReportsList.Add(Report);

                            }
                            return ReportsList;

                        }
                    }
                }
            }

            public static int Delete(int ReportID)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("SP_Reports_DeleteReportByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("ID", ReportID);
                        conn.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();
                        return RowsAffected;
                    }
                }
            }

          
            public static int Add()
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Reports_AddNewReport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();
                        return RowsAffected;

                    }
                }
            }
        }

    }

