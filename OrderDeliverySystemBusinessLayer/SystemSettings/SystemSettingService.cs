using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemBusinessLayer.salary;
using OrderDeliverySystemDataAccessLayer.SystemSetting;

namespace OrderDeliverySystemBusinessLayer.SystemSettings
{
    public class SystemSettingService
    {
        public SystemSettingService(SystemSettingDTO SystemSetting) 
        {
            this.SystemSettingID=SystemSetting.SystemSettingID;
            this.SettingName=SystemSetting.SettingName;
            this.SettingValue=SystemSetting.SettingValue;
            this.LastUpdate= SystemSetting.LastUpdate;
            this.IsDeleted= SystemSetting.IsDeleted;
        }
        public SystemSettingService() { }
        public int SystemSettingID { get; set; }
        public string SettingName { get; set; }
        public decimal SettingValue { get; set; }
        public string LastUpdate { get; set; }
        public bool IsDeleted { get; set; }


        public static SystemSettingDTO Find(int SystemSettingID)
        {
            return SystemSettinData.Find(SystemSettingID);
        }

        public static List<SystemSettingDTO> FindAll()
        {
            List<SystemSettingDTO> OrdersList = SystemSettinData.FindAll() ?? new List<SystemSettingDTO>();
            return OrdersList;
        }

        public static int Delete(int id)
        {
            return SystemSettinData.Delete(id);
        }

        public static int Update(SystemSettingDTO UpdatedSystemSetting)
        {
            if (UpdatedSystemSetting == null)
                throw new ArgumentNullException(nameof(UpdatedSystemSetting));

            return SystemSettinData.Updated(UpdatedSystemSetting);
        }

        public static int AddNew(SystemSettingDTO NewSystemSetting)
        {
            return SystemSettinData.AddNew(NewSystemSetting);
        }

    }
}
