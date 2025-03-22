using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.DriverRating;

namespace OrderDeliverySystemBusinessLayer.DriverRating
{
    public class DriverRatingService
    {
        public DriverRatingDTO DDTO => new DriverRatingDTO(RatingID,Rating,Review,RatingDate,OrderID,IsDeleted,DriverID);
        public DriverRatingService(DriverRatingDTO DriverRating)
        {
            RatingID = DriverRating.RatingID;
            Review = DriverRating.Review;
            RatingDate = DriverRating.RatingDate;
            OrderID = DriverRating.OrderID;
            IsDeleted = DriverRating.IsDeleted;
            DriverRatingID = DriverRating.DriverID;
        }
        public DriverRatingService() { }
        public int PersonID { get; set; }
        public int RatingID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public string RatingDate { get; set; }
        public int DriverRatingID { get; set; }
        public int OrderID { get; set; }
        public bool IsDeleted { get; set; }
        public int DriverID { get; set; }

        public static DriverRatingService Get(int DriverRatingID)
        {

            return new DriverRatingService(DriverRatingData.Get(DriverRatingID));
        }

        public static List<DriverRatingService> DriverRatingsList()
        {
            List<DriverRatingDTO> DriverRatingsList = DriverRatingData.GetAll();
            return DriverRatingsList.Select(DriverRating => new DriverRatingService(DriverRating)).ToList();
        }
        public static int Delete(int DriverRatingID)
        {
            return DriverRatingData.Delete(DriverRatingID);
        }
        public static int Update(DriverRatingDTO UpdatedDriverRating)
        {
            return DriverRatingData.Update(UpdatedDriverRating);
        }

        public static int AddNew(DriverRatingDTO UpdatedDriverRating)
        {
            return DriverRatingData.AddNew(UpdatedDriverRating);
        }

    }
}
