using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.DriverPermissions
{


    public class DriverPermissionsDTO
    {
        public DriverPermissionsDTO
                                  (
                                   int DriverPermissionsID, int DriverID,
                                   bool ViewAssignedOrders, bool UpdateOrderStatus, bool RejectOrder,
                                   bool ViewDeliveryRoute, bool CalculateDistance, bool ConfirmPayments,
                                   bool ViewEarnings, bool EditeProfile, bool ChangePassword, bool ViewRatings,
                                   bool ContactSupport, bool IsDeleted
                                  )
        {
            this.DriverPermissionsID = DriverPermissionsID;
            this.DriverID = DriverID;
            this.ViewAssignedOrders = ViewAssignedOrders;
            this.UpdateOrderStatus = UpdateOrderStatus;

            this.RejectOrder = RejectOrder;
            this.ViewDeliveryRoute = ViewDeliveryRoute;
            this.CalculateDistance = CalculateDistance;
            this.ConformPayments = ConfirmPayments;

            this.ViewEarnings = ViewEarnings;
            this.EditeProfile = EditeProfile;
            this.ChangePassword = ChangePassword;
            this.ViewRatings = ViewRatings;
            this.ContactSupport = ContactSupport;
            this.IsDeleted = IsDeleted;
        }
        public DriverPermissionsDTO() { }
        public int DriverPermissionsID { get; set; }
        public int DriverID { get; set; }
        public bool ViewAssignedOrders { get; set; }
        public bool UpdateOrderStatus { get; set; }
        public bool RejectOrder { get; set; }
        public bool ViewDeliveryRoute { get; set; }

        public bool CalculateDistance { get; set; }
        public bool ConformPayments { get; set; }
        public bool ViewEarnings { get; set; }
        public bool EditeProfile { get; set; }


        public bool ChangePassword { get; set; }
        public bool ViewRatings { get; set; }
        public bool ContactSupport { get; set; }
        public bool IsDeleted { get; set; }

    }

    public class DriverPermissionsData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        public static DriverPermissionsDTO Get(int DriverID)
        {
            DriverPermissionsDTO Driver = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_GetDriverPermissions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DriverID", DriverID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Driver = new DriverPermissionsDTO
                           (
                           reader.GetInt32(reader.GetOrdinal("DriverPermissionsID")),
                           reader.GetInt32(reader.GetOrdinal("DriverID")),

                           reader.GetBoolean(reader.GetOrdinal("ViewAssignedOrders")),
                           reader.GetBoolean(reader.GetOrdinal("UpdateOrderStatus")),
                           reader.GetBoolean(reader.GetOrdinal("RejectOrder")),
                           reader.GetBoolean(reader.GetOrdinal("ViewDeliveryRoute")),

                           reader.GetBoolean(reader.GetOrdinal("CalculateDistance")),
                           reader.GetBoolean(reader.GetOrdinal("ConfirmPayments")),
                           reader.GetBoolean(reader.GetOrdinal("ViewEarnings")),
                           reader.GetBoolean(reader.GetOrdinal("EditeProfile")),

                           reader.GetBoolean(reader.GetOrdinal("ChangePassword")),
                           reader.GetBoolean(reader.GetOrdinal("ViewRatings")),
                           reader.GetBoolean(reader.GetOrdinal("ContactSupport")),
                           reader.GetBoolean(reader.GetOrdinal("IsDeleted"))                          );
                        }
                        return Driver;
                    }
                }
            }
        }
      
      
        public static int Change(DriverPermissionsDTO ChangedDriverPermissions)
        {
            DriverPermissionsDTO Driver = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Drivers_UpdateDriverPermissions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("DriverID", ChangedDriverPermissions.DriverID);
                    cmd.Parameters.AddWithValue("UViewAssignedOrders", ChangedDriverPermissions.DriverID);
                    cmd.Parameters.AddWithValue("UupdateOrderStatus", ChangedDriverPermissions.ViewAssignedOrders);
                    cmd.Parameters.AddWithValue("URejectOrder", ChangedDriverPermissions.UpdateOrderStatus);

                    cmd.Parameters.AddWithValue("UViewDeliveryRoute", ChangedDriverPermissions.RejectOrder);
                    cmd.Parameters.AddWithValue("UCalculateDistance", ChangedDriverPermissions.ViewDeliveryRoute);
                    cmd.Parameters.AddWithValue("UConfirmPayments", ChangedDriverPermissions.CalculateDistance);

                    cmd.Parameters.AddWithValue("UEditeProfile", ChangedDriverPermissions.EditeProfile);
                    cmd.Parameters.AddWithValue("UChangePassword", ChangedDriverPermissions.ChangePassword);
                    cmd.Parameters.AddWithValue("UViewRatings", ChangedDriverPermissions.ViewRatings);

                    cmd.Parameters.AddWithValue("UContactSupport", ChangedDriverPermissions.ContactSupport);
                    conn.Open();
                    int Rowcount = cmd.ExecuteNonQuery();
                    return Rowcount;
                }
            }
        }

    }

}
