using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Customer.CustomerPermissions;

namespace OrderDeliverySystemBusinessLayer.Customer.CustomerPermissions
{
    public class CustomerPermissionsService
    {

        public CustomerPermissionsService(CustomerPermissionsDTO ChangedCustomerPermissions)
        {
            this.CustomerPermissionID = ChangedCustomerPermissions.CustomerPermissionID;
            this.CreateOrder =ChangedCustomerPermissions.CreateOrder;
            this.CancelOrder = ChangedCustomerPermissions.CancelOrder;
            this.TrackOrder = ChangedCustomerPermissions.TrackOrder;

            this.ViewOrderHistory = ChangedCustomerPermissions.ViewOrderHistory;
            this.EditeProfile = ChangedCustomerPermissions.EditeProfile;
            this.ChangePassword =ChangedCustomerPermissions.ChangePassword;
            this.MakePayments = ChangedCustomerPermissions.MakePayments;

            this.ViewInoices = ChangedCustomerPermissions.ViewInoices;
            this.RateDriver = ChangedCustomerPermissions.RateDriver;
            this.SubmitFeedback = ChangedCustomerPermissions.SubmitFeedback;
            this.ContactSupport = ChangedCustomerPermissions.ContactSupport;

            this.CustomerID = ChangedCustomerPermissions.CustomerID;
            this.IsDeleted = ChangedCustomerPermissions.IsDeleted;
        }
        public int CustomerPermissionID { get; set; }
        public bool CreateOrder { get; set; }
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

        public int CustomerID { get; set; }
        public bool IsDeleted { get; set; }

        public int ChangeCustomerPermissions(CustomerPermissionsDTO customerPermissionsDTO)
        {
            return CustomerPermissionsData.ChangeCustomerPermissions(customerPermissionsDTO);
        }
        public static CustomerPermissionsService Get(int CustomerID)
        {
            CustomerPermissionsDTO CustomerPermissions = CustomerPermissionsData.Get(CustomerID)?? new CustomerPermissionsDTO();
            return new CustomerPermissionsService(CustomerPermissions);
        }
    }
}
