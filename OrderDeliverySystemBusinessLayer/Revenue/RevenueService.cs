using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Order;
using RevenueDeliverySystemDataAccessLayer.Revenue;

namespace OrderDeliverySystemBusinessLayer.Revenue
{
    public class RevenueService
    {
        public RevenueService(RevenueDTO Revenue)
        {
            this.RevenueID = Revenue.RevenueID;
            this.Amount = Revenue.Amount;
            this.RevenueDate = Revenue.RevenueDate;
            this.Notes = Revenue.Notes;
            this.OrderID = Revenue.OrderID;
            this.CustomerID = Revenue.CustomerID;
            this.EmployeeID = Revenue.EmployeeID;
            this.AdminID = Revenue.AdminID;
            this.IsDeleted = Revenue.IsDeleted;
        }
        public RevenueService() { }
        public int RevenueID { get; set; }
        public decimal Amount { get; set; }
        public string RevenueDate { get; set; }
        public string Notes { get; set; }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int AdminID { get; set; }
        public bool IsDeleted { get; set; }

        public static RevenueDTO Find(int ID)
        {
            return RevenueData.Find(ID);
        }

        public static List<RevenueDTO> FindAll()
        {
            List<RevenueDTO> OrdersList = RevenueData.FindAll() ?? new List<RevenueDTO>();
            return OrdersList;
        }

        public static int Delete(int id)
        {
            return RevenueData.Delete(id);
        }

        public static int UpdatePerson(RevenueDTO UpdatedRevenue)
        {
            if (UpdatedRevenue == null)
                throw new ArgumentNullException(nameof(UpdatedRevenue));

            return RevenueData.Update(UpdatedRevenue);
        }

        public static int AddNewPerson(RevenueDTO NewRevenue)
        {
            return RevenueData.Add(NewRevenue);
        }
    }
}
