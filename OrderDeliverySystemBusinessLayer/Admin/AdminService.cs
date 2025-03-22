using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using OrderDeliverySystemBusinessLayer.Person;
using OrderDeliverySystemDataAccessLayer.Admin;
//using OrderDeliverySystemDataAccessLayer.People;

namespace OrderDeliverySystemBusinessLayer.Admin
{
    public class AdminService
    {
        public AdminDTO ADTO => new AdminDTO
                                    (AdminID,PersonID,UserName,PasswordHash );
        public int AdminID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

       


        public AdminService() { }
        public AdminService(AdminDTO ADTO)
        {
            if (ADTO == null)
                throw new ArgumentNullException(nameof(ADTO));
            AdminID = ADTO.AdminID;
            UserName = ADTO.UserName;
            PasswordHash = ADTO.PasswordHash;
            PersonID = ADTO.PersonID;
        }

        public static AdminService Find()
        {
            var Admindto = AdminData.Find();
            return Admindto != null ? new AdminService(Admindto) : null;
        }

        public static int Update(AdminDTO Admin)
        {
            return AdminData.Update(Admin);
        }
    }
}
