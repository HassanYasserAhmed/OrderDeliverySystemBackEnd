using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OrderDeliverySystemDataAccessLayer.DriverPermissions;

namespace OrderDeliverySystemDataAccessLayer.Employee
{
    public class EmployeePermissionsDTO
    {
        public EmployeePermissionsDTO(int EmployeePermissionsID, bool AssignDriver,
                                        bool UpdateOrderStatus, bool ViewCustomers, bool EditeCustomerInfo,
                                       bool ViewDrivers, bool UpdateDriverStatus, bool ViewReports,
                                       bool EditeProfile, bool ChangePassword, bool ContactSupport,
                                        bool RespondToCustomerInquires,bool IsDeleted, int EmployeeID
                                      )
        {
            this.EmployeePermissionsID = EmployeePermissionsID;
            this.AssignDriver = AssignDriver;
            this.UpdateOrderStatus = UpdateOrderStatus;
            this.ViewCustomers = ViewCustomers;
            this.EditeCustomerInfo = EditeCustomerInfo;

            this.ViewDrivers = ViewDrivers;
            this.UpdateDriverStatus = UpdateDriverStatus;
            this.ViewReports = ViewReports;
            this.EditeProfile = EditeProfile;
            this.ChangePassword = ChangePassword;

            this.ContactSupport = ContactSupport;
            this.RespondToCustomerInquires = RespondToCustomerInquires;
            this.IsDeleted = IsDeleted;
            this.EmployeeID = EmployeeID;
        }
        public EmployeePermissionsDTO() { }
        public int EmployeePermissionsID { get; set; }
        public bool AssignDriver { get; set; }
        public bool UpdateOrderStatus { get; set; }
        public bool ViewCustomers { get; set; }
        public bool EditeCustomerInfo { get; set; }

        public bool ViewDrivers { get; set; }
        public bool UpdateDriverStatus { get; set; }
        public bool ViewReports { get; set; }
        public bool EditeProfile { get; set; }

        public bool ChangePassword { get; set; }
        public bool ContactSupport { get; set; }
        public bool RespondToCustomerInquires { get; set; }
        public bool IsDeleted { get; set; }
        public int EmployeeID { get; set; }
    }
  

        public class EmployeePermissionsData
        {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static EmployeePermissionsDTO Get(int DriverID)
            {
                EmployeePermissionsDTO employeePermissions = null;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Employees_GetEmployeePermissionByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("ID", DriverID);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                            employeePermissions = new EmployeePermissionsDTO
                           (
                           reader.GetInt32(reader.GetOrdinal("EmployeePermissionsID")),

                           reader.GetBoolean(reader.GetOrdinal("AssignDriver")),
                           reader.GetBoolean(reader.GetOrdinal("UpdateOrderStatus")),
                           reader.GetBoolean(reader.GetOrdinal("ViewCustomers")),
                           reader.GetBoolean(reader.GetOrdinal("EditCustomersInfo")),

                           reader.GetBoolean(reader.GetOrdinal("ViewDrivers")),
                           reader.GetBoolean(reader.GetOrdinal("UpdateDriverStatus")),
                           reader.GetBoolean(reader.GetOrdinal("ViewReports")),
                           reader.GetBoolean(reader.GetOrdinal("EditeProfile")),

                           reader.GetBoolean(reader.GetOrdinal("ChangePassword")),
                           reader.GetBoolean(reader.GetOrdinal("ContactSupport")),
                           reader.GetBoolean(reader.GetOrdinal("RespondToCustomerInquires")),
                           reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                           reader.GetInt32(reader.GetOrdinal("EmployeeID")));
                            }
                            return employeePermissions;
                        }
                    }
                }
            }


            public static int Change(EmployeePermissionsDTO ChangedEmployeePermissinos)
            {
                EmployeePermissionsDTO Driver = null;
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Employees_ChangedEmployeePermissionByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("ID", ChangedEmployeePermissinos.EmployeeID);
                        cmd.Parameters.AddWithValue("UAssignDriver", ChangedEmployeePermissinos.AssignDriver);
                        cmd.Parameters.AddWithValue("UUpdateOrderStatus", ChangedEmployeePermissinos.UpdateDriverStatus);
                        cmd.Parameters.AddWithValue("UViewCustomers", ChangedEmployeePermissinos.ViewCustomers);

                        cmd.Parameters.AddWithValue("UEditeCustomersInfo", ChangedEmployeePermissinos.EditeCustomerInfo);
                        cmd.Parameters.AddWithValue("UViewDrivers", ChangedEmployeePermissinos.ViewDrivers);
                        cmd.Parameters.AddWithValue("UUpdateDriverStatus", ChangedEmployeePermissinos.UpdateDriverStatus);

                        cmd.Parameters.AddWithValue("UViewReportS", ChangedEmployeePermissinos.ViewReports);
                        cmd.Parameters.AddWithValue("UEditeProfile", ChangedEmployeePermissinos.EditeProfile);
                        cmd.Parameters.AddWithValue("UChangePassword", ChangedEmployeePermissinos.ChangePassword);

                        cmd.Parameters.AddWithValue("UContactSupport", ChangedEmployeePermissinos.ContactSupport);
                        cmd.Parameters.AddWithValue("URespondToCustomerInquires", ChangedEmployeePermissinos.RespondToCustomerInquires);
                        conn.Open();
                        int Rowcount = cmd.ExecuteNonQuery();
                        return Rowcount;
                    }
                }
            }

        }

    }

