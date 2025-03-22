using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.Customer.CustomerPermissions
{
    public class CustomerPermissionsDTO
    {

        public CustomerPermissionsDTO(int CustomerPermissionID, bool CreateOrder, bool CancelOrder, bool TrackOrder, bool ViewOrderHistory,
                                     bool EditeProfile, bool ChangePassword, bool MakePayments, bool ViewInoices, bool RatteDriver,
                                     bool SubmitFeedback, bool ContactSupport, int CustomerID, bool IsDeleted)
        {
            this.CustomerPermissionID = CustomerPermissionID;
            this.CreateOrder = CreateOrder;
            this.CancelOrder = CancelOrder;
            this.TrackOrder = TrackOrder;

            this.ViewOrderHistory = ViewOrderHistory;
            this.EditeProfile = EditeProfile;
            this.ChangePassword = ChangePassword;
            this.MakePayments = MakePayments;

            this.ViewInoices = ViewInoices;
            this.RateDriver = RateDriver;
            this.SubmitFeedback = SubmitFeedback;
            this.ContactSupport = ContactSupport;

            this.CustomerID = CustomerID;
            this.IsDeleted = IsDeleted;
        }
        public CustomerPermissionsDTO() { }
        public int CustomerPermissionID { get; set; }
        public bool CreateOrder {  get; set; }
        public bool CancelOrder { get; set; }
        public bool TrackOrder { get; set; }

        public bool ViewOrderHistory { get; set; }
        public bool EditeProfile { get; set; }
        public bool ChangePassword { get; set; }
        public bool MakePayments { get; set; }

        public bool ViewInoices { get; set; }
        public bool RateDriver { get; set; }
        public bool SubmitFeedback { get; set; }
        public bool ContactSupport { get; set; }

        public int CustomerID {  get; set; }
        public bool IsDeleted { get; set; }
    }
    public class CustomerPermissionsData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";


        public static int ChangeCustomerPermissions(CustomerPermissionsDTO ChangedCustomerPermission)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_ChangeCustomerPermissions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("CustomerID", ChangedCustomerPermission.CustomerID);
                    cmd.Parameters.AddWithValue("UCreateOrder", ChangedCustomerPermission.CreateOrder);
                    cmd.Parameters.AddWithValue("UCancelOrder", ChangedCustomerPermission.CreateOrder);
                    cmd.Parameters.AddWithValue("UTrackOrder", ChangedCustomerPermission.TrackOrder);

                    cmd.Parameters.AddWithValue("UViewOrderHistory", ChangedCustomerPermission.ViewOrderHistory);
                    cmd.Parameters.AddWithValue("UEditeProfile", ChangedCustomerPermission.EditeProfile);
                    cmd.Parameters.AddWithValue("UChangePassword", ChangedCustomerPermission.ChangePassword);
                    cmd.Parameters.AddWithValue("UMakePayments", ChangedCustomerPermission.MakePayments);

                    cmd.Parameters.AddWithValue("UViewInoices", ChangedCustomerPermission.ViewInoices);
                    cmd.Parameters.AddWithValue("URateDriver", ChangedCustomerPermission.RateDriver);
                    cmd.Parameters.AddWithValue("USubmitFeedback", ChangedCustomerPermission.SubmitFeedback);
                    cmd.Parameters.AddWithValue("UContactSupport", ChangedCustomerPermission.ContactSupport);


                    int RwosAffected = cmd.ExecuteNonQuery();
                    return RwosAffected;   
                }
            }
        }

        public static CustomerPermissionsDTO Get(int CustomerID)
        {
            CustomerPermissionsDTO CustomerPermissions = null;
            using (SqlConnection conn = new SqlConnection (_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Customers_GetCustomerPermissions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("CustomerID", CustomerID);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            CustomerPermissions = new CustomerPermissionsDTO
                            (
                            reader.GetInt32(reader.GetOrdinal("CustomerPermissionsID")),
                            reader.GetBoolean(reader.GetOrdinal("CreateOrder")),
                            reader.GetBoolean(reader.GetOrdinal("CancelOrder")),
                            reader.GetBoolean(reader.GetOrdinal("TrackOrder")),

                            reader.GetBoolean(reader.GetOrdinal("ViewOrderHistory")),
                            reader.GetBoolean(reader.GetOrdinal("EditeProfile")),
                            reader.GetBoolean(reader.GetOrdinal("ChangePassword")),
                            reader.GetBoolean(reader.GetOrdinal("MakePayments")),

                            reader.GetBoolean(reader.GetOrdinal("ViewInoices")),
                            reader.GetBoolean(reader.GetOrdinal("RateDriver")),
                            reader.GetBoolean(reader.GetOrdinal("SubmitFeedback")),
                            reader.GetBoolean(reader.GetOrdinal("ContactSupport")),

                            reader.GetInt32(reader.GetOrdinal("CustomerID")),
                            reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                            );
                        }
                        return CustomerPermissions;
                    }
                }
            }
        }
    }
}
