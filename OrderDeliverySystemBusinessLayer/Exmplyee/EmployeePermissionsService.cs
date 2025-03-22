using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemBusinessLayer.Customer.CustomerPermissions;
using OrderDeliverySystemDataAccessLayer.Customer.CustomerPermissions;
using OrderDeliverySystemDataAccessLayer.Employee;

namespace OrderDeliverySystemBusinessLayer.Exmplyee
{
    public  class EmployeePermissionsService
    {
        public EmployeePermissionsDTO EPDTO => new EmployeePermissionsDTO(EmployeePermissionsID, AssignDriver, 
                                                                            UpdateDriverStatus, ViewCustomers, EditeCustomerInfo, 
                                                                            ViewDrivers, UpdateDriverStatus, ViewReports, EditeProfile,
                                                                            ChangePassword, ContactSupport, RespondToCustomerInquires, 
                                                                             IsDeleted,EmployeeID);
        public EmployeePermissionsService(EmployeePermissionsDTO EmployeePermissions)
        {
            EmployeePermissionsID = EmployeePermissions.EmployeePermissionsID;
            AssignDriver = EmployeePermissions.AssignDriver;
            UpdateOrderStatus = EmployeePermissions.UpdateOrderStatus;
            ViewCustomers = EmployeePermissions.ViewCustomers;
            EditeCustomerInfo = EmployeePermissions.EditeCustomerInfo;

            ViewDrivers = EmployeePermissions.ViewDrivers;
            UpdateDriverStatus = EmployeePermissions.UpdateDriverStatus;
            ViewReports = EmployeePermissions.ViewReports;
            EditeProfile = EmployeePermissions.EditeProfile;
            ChangePassword = EmployeePermissions.ChangePassword;

            ContactSupport = EmployeePermissions.ContactSupport;
            RespondToCustomerInquires= EmployeePermissions.RespondToCustomerInquires;
            EmployeeID = EmployeePermissions.EmployeeID;
            IsDeleted = EmployeePermissions.IsDeleted;
        }
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
        public int EmployeeID { get; set; }
        public bool IsDeleted { get; set; }

        public int ChangeEmployeePermissions(EmployeePermissionsDTO ChangeEmployeePermissions)
        {
            return EmployeePermissionsData.Change(ChangeEmployeePermissions);
        }
        public static EmployeePermissionsDTO Get(int EmployeeID)
        {
            EmployeePermissionsDTO employeePermissions = EmployeePermissionsData.Get(EmployeeID) ?? new EmployeePermissionsDTO();
            return employeePermissions;
        }
    }
}
