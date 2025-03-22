using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Driver;

namespace OrderDeliverySystemBusinessLayer.Driver
{
    public class DriverService
    {
        public DriverDTO DDTO => new DriverDTO(PersonID,DriverID, UserName, VehicalType, VehicalLicense, Status,
                                              PasswordHash, IsActive, CreatedAt, UpdatedAt, IsDeleted);
        public DriverService(DriverDTO Driver)
        {
            this.DriverID = Driver.DriverID;
            this.UserName = Driver.UserName;
            this.VehicalType = Driver.VehicalType;
            this.VehicalLicense = Driver.VehicalLicense;
            this.Status = Driver.Status;
            this.PasswordHash = Driver.PasswordHash;
            this.IsActive = Driver.IsActive;
            this.CreatedAt = Driver.CreatedAt;
            this.UpdatedAt = Driver.UpdatedAt;
            this.IsDeleted = Driver.IsDeleted;
            this.PersonID = Driver.PersonID;
        }
        public DriverService() { }
        public int PersonID { get; set; }

        public int DriverID { get; set; }
        public string UserName { get; set; }
        public string VehicalType { get; set; }
        public string VehicalLicense { get; set; }
        public string Status { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public static DriverService Get(int DriverID)
        {

            return new DriverService(DriverData.Get(DriverID));
        }

        public static List<DriverService> DriversList()
        {
            List<DriverDTO> DriversList = DriverData.GetAll();
            return DriversList.Select(Driver => new DriverService(Driver)).ToList();
        }
        public static int Delete(int DriverID)
        {
            return DriverData.Delete(DriverID);
        }
        public static int Update(DriverDTO UpdatedDriver)
        {
            return DriverData.Update(UpdatedDriver);
        }

        public static int AddNew(DriverDTO UpdatedDriver)
        {
            return DriverData.AddNew(UpdatedDriver);
        }

    }
}
