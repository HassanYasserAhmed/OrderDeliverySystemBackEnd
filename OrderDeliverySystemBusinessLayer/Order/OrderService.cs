using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemBusinessLayer.Person;
using OrderDeliverySystemDataAccessLayer.Order;
using OrderDeliverySystemDataAccessLayer.People;

namespace OrderDeliverySystemBusinessLayer.Order
{
    public class OrderService
    {
        public OrderService(OrderDTO Order) 
                            { 
            OrderID = Order.OrderID;
            OrderStatus = Order.OrderStatus;
            OrderDetails = Order.OrderDetails;
            Price = Order.Price;
            OrderDate = Order.OrderDate;

            ExpectedDeleveryDate = Order.ExpectedDeleveryDate;
            PaymentStatus = Order.PaymentStatus;
            PayamentMethod = Order.PayamentMethod;
            RecieverName = Order.RecieverName;
            Weight = Order.Weight;

            RecieverPhone = Order.RecieverPhone;
            CustomerID = Order.CustomerID;
            DriverID = Order.DriverID;
            AreaID = Order.AreaID;
            IsDeleted = Order.IsDeleted;
            SenderLocation = Order.SenderLocation;
            ReciverLocation = Order.ReciverLocation;

                            }
        public OrderService() { }
        public int OrderID { get; set; }
        public string OrderStatus { get; set; }
        public string OrderDetails { get; set; }
        public decimal Price { get; set; }
        public string OrderDate { get; set; }

        public string ExpectedDeleveryDate { get; set; }
        public string PaymentStatus { get; set; }
        public string PayamentMethod { get; set; }
        public string RecieverName { get; set; }
        public float Weight { get; set; }

        public string RecieverPhone { get; set; }
        public int CustomerID { get; set; }
        public int DriverID { get; set; }
        public int AreaID { get; set; }
        public bool IsDeleted { get; set; }
        public string SenderLocation { get; set; }
        public string ReciverLocation { get; set; }


        public static OrderDTO Find(int ID)
        {
            return OrderData.Find(ID);
        }

        public static List<OrderDTO> FindAll()
        {
            List<OrderDTO> OrdersList = OrderData.FindAll() ?? new List<OrderDTO>();
            return OrdersList;
        }

        public static int Delete(int id)
        {
            return OrderData.Delete(id);
        }

        public static int UpdatePerson(OrderDTO UpdatedOrder)
        {
            if (UpdatedOrder == null)
                throw new ArgumentNullException(nameof(UpdatedOrder));

            return OrderData.Update(UpdatedOrder);
        }

        public static int AddNewPerson(OrderDTO NewOrder)
        {
            return OrderData.Add(NewOrder);
        }
    }
}
