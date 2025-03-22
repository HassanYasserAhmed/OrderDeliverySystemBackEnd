using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Employee;

namespace OrderDeliverySystemBusinessLayer.Employee
{
    public class EmployeeService
    {
        public EmployeeDTO EDTO => new EmployeeDTO(PersonID, EmployeeID, UserName, Status,
                                              PasswordHash, IsActive, CreatedAt, UpdatedAt, IsDeleted);
        public EmployeeService(EmployeeDTO Employee)
        {
            this.EmployeeID = Employee.EmployeeID;
            this.UserName = Employee.UserName;
            this.Status = Employee.Status;
            this.PasswordHash = Employee.PasswordHash;
            this.IsActive = Employee.IsActive;
            this.CreatedAt = Employee.CreatedAt;
            this.UpdatedAt = Employee.UpdatedAt;
            this.IsDeleted = Employee.IsDeleted;
            this.PersonID = Employee.PersonID;
        }
        public EmployeeService() { }
        public int PersonID { get; set; }

        public int EmployeeID { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public static EmployeeService Get(int EmployeeID)
        {

            return new EmployeeService(EmployeeData.Get(EmployeeID));
        }

        public static List<EmployeeService> EmployeesList()
        {
            List<EmployeeDTO> EmployeesList = EmployeeData.GetAll();
            return EmployeesList.Select(Employee => new EmployeeService(Employee)).ToList();
        }
        public static int Delete(int EmployeeID)
        {
            return EmployeeData.Delete(EmployeeID);
        }
        public static int Update(EmployeeDTO UpdatedEmployee)
        {
            return EmployeeData.Update(UpdatedEmployee);
        }

        public static int AddNew(EmployeeDTO NewEmployee)
        {
            return EmployeeData.AddNew(NewEmployee);
        }

    }
}
