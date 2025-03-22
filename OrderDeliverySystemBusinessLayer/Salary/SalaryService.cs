using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OrderDeliverySystemBusinessLayer.salary
{
    public class SalaryServiceDTO
    {
        public SalaryServiceDTO() { }
        public SalaryServiceDTO(int SalaryID, decimal BaseSalary, decimal Bonus, decimal Deductions, string SalaryMonth, decimal NetSalary,
           string PaymentsStatus, string PaymentDate, int PersonID, bool IsDeleted)
        {
            this.SalaryID = SalaryID;
            this.BaseSalary = BaseSalary;
            this.Bonus = Bonus;
            this.Deductions = Deductions;
            this.SalaryMonth = SalaryMonth;
            this.NetSalary = NetSalary;
            this.PaymentStatus = PaymentsStatus;
        }
        public int SalaryID { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public string SalaryMonth { get; set; }
        public decimal NetSalary { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentDate { get; set; }
        public int PersonID { get; set; }
        public bool IsDeleted { get; set; }


    }
    public class SalaryService
    {
        public static SalaryServiceDTO Find(int PersonID)
        {
            return SalaryService.Find(PersonID);
        }

        public static List<SalaryServiceDTO> FindAll()
        {
            List<SalaryServiceDTO> OrdersList = SalaryService.FindAll() ?? new List<SalaryServiceDTO>();
            return OrdersList;
        }

        public static int Delete(int id)
        {
            return SalaryService.Delete(id);
        }

        public static int Update(SalaryServiceDTO UpdatedOrder)
        {
            if (UpdatedOrder == null)
                throw new ArgumentNullException(nameof(UpdatedOrder));

            return SalaryService.Update(UpdatedOrder);
        }

        public static int AddNew(SalaryServiceDTO NewOrder)
        {
            return SalaryService.AddNew(NewOrder);
        }
    }
}