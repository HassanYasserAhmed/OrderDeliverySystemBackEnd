using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Customer.CustomerBalance;

namespace OrderDeliverySystemBusinessLayer.Customer.CustoemerBalance
{
    public class CustomerBalanceService
    {

        public CustomerBalanceService(CustomerBalanceDTO CustomerBalance)
        {
            this.BalanceID = CustomerBalance.BalanceID;
            this.CustomerID = CustomerBalance.CustomerID;
            this.Balance = CustomerBalance.Balance;
            this.PreviosBalance = CustomerBalance.PreviosBalance;
            this.CreatedAt = CustomerBalance.CreatedAt;
            this.LastUpdated = CustomerBalance.LastUpdated;
            this.IsLocked = CustomerBalance.IsLocked;
            this.IsDeleted = CustomerBalance.IsDeleted;
        }
        public CustomerBalanceService() { }

        public CustomerBalanceDTO CBDTO => new CustomerBalanceDTO(CustomerID, Balance, IsLocked, IsDeleted, BalanceID,
                                                                 PreviosBalance, CreatedAt, LastUpdated);
        public int? BalanceID { get; set; }
        public int CustomerID { get; set; }
        public decimal Balance { get; set; }
        public decimal? PreviosBalance { get; set; }
        public string? CreatedAt { get; set; }
        public string? LastUpdated { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeleted { get; set; }


        public  static CustomerBalanceService Get(int CustomerID)
        {
            CustomerBalanceDTO CustomerBalance = CustomerBalanceData.Get(CustomerID) ?? new CustomerBalanceDTO();
            return new CustomerBalanceService(CustomerBalance);
        }
        public static int CreditDebitBalance(decimal Amount,int CustomerID)
        {
            return CustomerBalanceData.CreditDebitBalance(Amount,CustomerID);
        }
    }
}
