using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.DriverPermissions;

namespace OrderDeliverySystemBusinessLayer.Driver
{
    public class DriverPermissionsService
    {
        public DriverPermissionsDTO DPDTO => new DriverPermissionsDTO(DriverPermissionsID, DriverID, ViewAssignedOrders,
                                                                    UpdateOrderStatus, RejectOrder, ViewDeliveryRoute,
                                                                    CalculateDistance, ConfirmPayments, ViewEarnings,
                                                                    EditeProfile, ChangePassword, ViewRatings, ContactSupport,
                                                                    IsDeleted);

        public DriverPermissionsService(DriverPermissionsDTO DriverPermissions)
        {
            DriverPermissionsID = DriverPermissions.DriverPermissionsID;
            DriverID = DriverPermissions.DriverID;
            ViewAssignedOrders = DriverPermissions.ViewAssignedOrders;
            UpdateOrderStatus = DriverPermissions.UpdateOrderStatus;
            RejectOrder = DriverPermissions.RejectOrder;
            ViewDeliveryRoute = DriverPermissions.ViewDeliveryRoute;
            CalculateDistance = DriverPermissions.CalculateDistance;
            ConfirmPayments = DriverPermissions.ConformPayments;
            ViewEarnings = DriverPermissions.EditeProfile;
            EditeProfile = DriverPermissions.EditeProfile;
            ChangePassword = DriverPermissions.ChangePassword;
            ViewRatings = DriverPermissions.ViewRatings;
            ContactSupport = DriverPermissions.ContactSupport;
            IsDeleted = DriverPermissions.IsDeleted;
        }
        public DriverPermissionsService() { }
        public int DriverPermissionsID { get; set; }
        public int DriverID { get; set; }
        public bool ViewAssignedOrders { get; set; }
        public bool UpdateOrderStatus { get; set; }
        public bool RejectOrder { get; set; }
        public bool ViewDeliveryRoute { get; set; }

        public bool CalculateDistance { get; set; }
        public bool ConfirmPayments { get; set; }
        public bool ViewEarnings { get; set; }
        public bool EditeProfile { get; set; }


        public bool ChangePassword { get; set; }
        public bool ViewRatings { get; set; }
        public bool ContactSupport { get; set; }
        public bool IsDeleted { get; set; }

        public static DriverPermissionsService Get(int DriverID)
        {
            return new DriverPermissionsService(DriverPermissionsData.Get(DriverID));
        }

        public static int Change(DriverPermissionsDTO ChangedDriverPermissions)
        {
            return DriverPermissionsData.Change(ChangedDriverPermissions);
        }

    }
}
