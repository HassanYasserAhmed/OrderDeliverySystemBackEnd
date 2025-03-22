using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Area;
using OrderDeliverySystemDataAccessLayer.Customer;

namespace OrderDeliverySystemBusinessLayer.Customer
{
    public class CustomerService
    {
        public CustomerService(CustomerDTO CDTO) 
        { 
            this.CustomerID = CDTO.CustomerID;
            this.PersonID = CDTO.PersonID;
            this.UserName = CDTO.UserName;
            this.PasswordHash = CDTO.PasswordHash;

            this.Status = CDTO.Status;
            this.IsActive = CDTO.IsActive;
            this.Datejoined = CDTO.Datejoined;
            this.LastUpdated = CDTO.LastUpdated;
            this.IsDeleted = CDTO.IsDeleted;
        }
        public CustomerDTO CDTO => new CustomerDTO(CustomerID, PersonID, UserName, PasswordHash,
                                                  Status, IsActive, Datejoined, LastUpdated, IsDeleted);

        public int CustomerID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string? PaymentMethod { get; set; }

        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string? Datejoined { get; set; }
        public string? LastUpdated { get; set; }

        public bool? IsDeleted { get; set; }


        public  int AddNewCustomer(CustomerDTO NewCustomer)
        {
           return CustomerData.AddNew(NewCustomer);
        }

        public  CustomerService Find(int ID)
        {
           CustomerDTO Customer = CustomerData.Find(ID);
         return  Customer != null ? new CustomerService(Customer) : null;
        }
        public List<CustomerService> FindAll()
        {
            var CustomersList = CustomerData.FindAll() ?? new List<CustomerDTO>();
            return CustomersList.Select(Customer => new CustomerService(Customer)).ToList();
        }

        public int Delete(int id)
        {
            return CustomerData.Delete(id);
        }
        public int Update(CustomerDTO Customer)
        {
            return CustomerData.Update(Customer);
        }

    }
}
