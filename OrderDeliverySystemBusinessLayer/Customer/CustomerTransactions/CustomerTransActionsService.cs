using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Customer;
using OrderDeliverySystemDataAccessLayer.Customer.CustomerTransactions;

namespace OrderDeliverySystemBusinessLayer.Customer.CustomerTransactions
{
    public class CustomerTranactionsService
    {
        public CustomerTranactionsService(CustomerTranactionsDTO CustomerTransaction) 
        {
            this.CustomerTransActionsID = CustomerTransaction.CustomerTransActionsID;
            this.Amount = CustomerTransaction.Amount;
            this.TransactionType = CustomerTransaction.TransactionType;
            this.TransactionDate =CustomerTransaction.TransactionDate;
            this.Notes = CustomerTransaction.Notes;
            this.CustomerId = CustomerTransaction.CustomerId;
            this.IsDeleted = CustomerTransaction.IsDeleted;
        }
        public CustomerTranactionsDTO CTDTA => new CustomerTranactionsDTO(CustomerTransActionsID,Amount,TransactionType,
                                                                         TransactionDate,Notes,CustomerId,IsDeleted,PaymentMethod);
        public int CustomerTransActionsID { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDate { get; set; }
        public string Notes { get; set; }
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }
        public string PaymentMethod { get; set; }  

        public List<CustomerTranactionsService> FindAll(int CustomerID)
        {
            var  CustomerTransactionsList = CustomerTransActionsData.FindAll(CustomerID) ?? new List<CustomerTranactionsDTO>();

            return CustomerTransactionsList.Select(CustomerTrasaction => new CustomerTranactionsService(CustomerTrasaction)).ToList();
        }
        public int AddNew(CustomerTranactionsDTO NewCustomerTransaction)
        {
            return CustomerTransActionsData.AddNew(NewCustomerTransaction); 
        }

    }
}
