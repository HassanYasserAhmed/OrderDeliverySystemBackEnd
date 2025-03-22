using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Driver;

namespace OrderDeliverySystemBusinessLayer.Driver
{
    public class DriverEarningService
    {
        public DriverEarningDTO DEDTO => new DriverEarningDTO(EarningID, Amount, EarningDate, DriverID, IsDeleted,OrderID);
        public DriverEarningService(DriverEarningDTO DriverEarning)
        {
            this.EarningID = DriverEarning.EarningID;
            this.Amount = DriverEarning.Amount;
            this.EarningDate = DriverEarning.EarningDate;
            this.DriverID = DriverEarning.DriverID;
            this.IsDeleted = DriverEarning.IsDeleted;
            this.OrderID = DriverEarning.OrderID;
        }
        public DriverEarningService() { }
        public int OrderID { get; set; }
        public int EarningID { get; set; }
        public decimal Amount { get; set; }
        public string EarningDate { get; set; }
        public int DriverID { get; set; }
        public bool IsDeleted { get; set; }



        public static DriverEarningService Get(int DriverID)
        {
           DriverEarningDTO DriverEarning = DriverEarningData.Get(DriverID);
            return new DriverEarningService(DriverEarning);
        }
        public static List<DriverEarningService> GetAll(int DriverID)
        {
            List<DriverEarningDTO> DriversList = DriverEarningData.GetAll(DriverID);
            return DriversList.Select(DriverEarning => new DriverEarningService(DriverEarning)).ToList();
        }

        public static int Delete(int DriverEarningID)
        {
            return DriverData.Delete(DriverEarningID);
        }
        public static int Update(DriverEarningDTO UpdatedDriver)
        {
            return DriverEarningData.Update(UpdatedDriver);
        }

        public static int AddNew(DriverEarningDTO UpdatedDriver)
        {
            return DriverEarningData.AddNew(UpdatedDriver);
        }
    }
}
