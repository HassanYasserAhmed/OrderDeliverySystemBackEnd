using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Area;

namespace OrderDeliverySystemBusinessLayer.Area
{ 
    public  class AreaService
    {
        public AreaDTO ADTO => new AreaDTO(AreaID, AreaName, Governerate, IsActive, DeliveryFee,
                                            CreatedAt, UpdatedAt, IsDeleted);

        public AreaService(AreaDTO Area)
        {
            this.AreaID =  Area.AreaID;
            this.AreaName = Area.AreaName;
            this.Governerate = Area.Governerate;
            this.IsActive = Area.IsActive;
            this.DeliveryFee = Area.DeliveryFee;

            this.CreatedAt = Area.CreatedAt;
            this.UpdatedAt = Area.UpdatedAt;
            this.IsDeleted = Area.IsDeleted;

        }
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string Governerate { get; set; }
        public bool IsActive { get; set; }

        public decimal DeliveryFee { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }


        public AreaService Find(int id)
        {
            AreaDTO Area = AreaData.Find(id);
            return Area != null ? new AreaService(Area) : null;
        }
        public List<AreaService> FindAll()
        {
            var Areas = AreaData.FindAll() ?? new List<AreaDTO>();
            return Areas.Select(AreaDTO => new AreaService(AreaDTO)).ToList();
        }
        public int Add(AreaDTO NewArea)
        {
            return AreaData.Add(NewArea);
        }
        public int Delete(int AreaID)
        {
            return AreaData.Delete(AreaID);
        }
        public int Update(AreaDTO Area)
        {
            return AreaData.Update(Area);
        }
    }


}
