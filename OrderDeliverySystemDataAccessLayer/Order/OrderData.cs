using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OrderDeliverySystemDataAccessLayer.Order;

namespace OrderDeliverySystemDataAccessLayer.Order
{
    public class OrderDTO
    {
        public OrderDTO(int OrderID,string OrderStatus,string OrderDetails, decimal Price, string OrderDate, string ExpectedDeleveryDate, string PaymentStatus,
            string PaymentMethod, string ReciverName, float Weight, string ReciverPhone, int CustomerID, int DriverID, int AreaID, bool IsDeleted,string SenderLocation,string ReciverLocation)
        {
            this.OrderID = OrderID;
            this.OrderStatus = OrderStatus;
            this.OrderDetails = OrderDetails;
            this.Price = Price;
            this.OrderDate = OrderDate;
            this.OrderDate = OrderDate;
            this.ExpectedDeleveryDate = ExpectedDeleveryDate;
            this.PaymentStatus = PaymentStatus;
            this.PayamentMethod = PaymentMethod;
            this.RecieverName = ReciverName;
            this.Weight = Weight;
            this.RecieverPhone = ReciverPhone;
            this.CustomerID = CustomerID;
            this.DriverID = DriverID;
            this.AreaID = AreaID;
            this.IsDeleted = IsDeleted;
            this.SenderLocation = SenderLocation;
            this.ReciverLocation = ReciverLocation;

        }
        public OrderDTO() { }
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

    }


    public class OrderData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static OrderDTO Find(int OrderID)
        {
            OrderDTO Order = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Orders_GetOrderById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", OrderID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Order = new OrderDTO(
                             reader.GetInt32(reader.GetOrdinal("OrderID")),
                             reader.GetString(reader.GetOrdinal("OrderStatus")),
                             reader.GetString(reader.GetOrdinal("OrderDetails")),
                             reader.GetDecimal(reader.GetOrdinal("Price")),
                             reader.GetDateTime(reader.GetOrdinal("OrderDate")).ToString("yyyy-MM-dd HH-mm-ss"),

                             reader.GetDateTime(reader.GetOrdinal("ExpectedDeliveryDate")).ToString("yyyy-MM-dd HH-mm-ss"),
                             reader.GetString(reader.GetOrdinal("PaymentStatus")),
                             reader.GetString(reader.GetOrdinal("PaymentMethod")),
                             reader.GetString(reader.GetOrdinal("RecieverName")),
                             (float)reader.GetDouble(reader.GetOrdinal("Weight")),

                             reader.GetString(reader.GetOrdinal("ReciverPhone")),
                             reader.GetInt32(reader.GetOrdinal("CustomerID")),
                             reader.GetInt32(reader.GetOrdinal("DriverID")),
                             reader.GetInt32(reader.GetOrdinal("AreaID")),
                             reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                             reader.GetString(reader.GetOrdinal("SenderLocation")),
                             reader.GetString(reader.GetOrdinal("ReciverLocation"))
                            );
                        }
                       

                    }

                }
            }

            return Order;
        }

        public static List<OrderDTO> FindAll()
        {
            List<OrderDTO> OrderList = new List<OrderDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SP_Orders_GetAllOrders", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var Order = new OrderDTO
                            (
                              reader.GetInt32(reader.GetOrdinal("OrderID")),
                             reader.GetString(reader.GetOrdinal("OrderStatus")),
                             reader.GetString(reader.GetOrdinal("OrderDetails")),
                             reader.GetDecimal(reader.GetOrdinal("Price")),
                             reader.GetDateTime(reader.GetOrdinal("OrderDate")).ToString("yyyy-MM-dd HH-mm-ss"),

                             reader.GetDateTime(reader.GetOrdinal("ExpectedDeliveryDate")).ToString("yyyy-MM-dd HH-mm-ss"),
                             reader.GetString(reader.GetOrdinal("PaymentStatus")),
                             reader.GetString(reader.GetOrdinal("PaymentMethod")),
                             reader.GetString(reader.GetOrdinal("RecieverName")),
                             (float)reader.GetDouble(reader.GetOrdinal("Weight")),

                             reader.GetString(reader.GetOrdinal("ReciverPhone")),
                             reader.GetInt32(reader.GetOrdinal("CustomerID")),
                             reader.GetInt32(reader.GetOrdinal("DriverID")),
                             reader.GetInt32(reader.GetOrdinal("AreaID")),
                             reader.GetBoolean(reader.GetOrdinal("IsDeleted")),
                             reader.GetString(reader.GetOrdinal("SenderLocation")),
                             reader.GetString(reader.GetOrdinal("ReciverLocation"))
                             );

                            OrderList.Add(Order);

                        }
                        return OrderList;

                    }
                }
            }
        }

        public static int Delete(int OrderID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_Orders_DeleteOrderById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", OrderID);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }

        public static int Update(OrderDTO UpdatedOrder)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Orders_UpdateOrderById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ID", UpdatedOrder.OrderID);
                    cmd.Parameters.AddWithValue("UOrderDetails", UpdatedOrder.OrderDetails);
                    cmd.Parameters.AddWithValue("UOrderPrice", UpdatedOrder.Price);
                    cmd.Parameters.AddWithValue("UPaymentStatus", UpdatedOrder.PaymentStatus);
                    cmd.Parameters.AddWithValue("UPaymentMethod", UpdatedOrder.PayamentMethod);
                    cmd.Parameters.AddWithValue("UReciverName", UpdatedOrder.RecieverName);
                    cmd.Parameters.AddWithValue("UWeight", UpdatedOrder.Weight);
                    cmd.Parameters.AddWithValue("UReciverPhone", UpdatedOrder.RecieverPhone);
                    cmd.Parameters.AddWithValue("UCustomerID", UpdatedOrder.CustomerID);
                    cmd.Parameters.AddWithValue("UDriverID", UpdatedOrder.DriverID);
                    cmd.Parameters.AddWithValue("UAreaID", UpdatedOrder.AreaID);
                    cmd.Parameters.AddWithValue("UExpectedDeliveryDate", UpdatedOrder.ExpectedDeleveryDate);
                    cmd.Parameters.AddWithValue("USenderLocation", UpdatedOrder.ExpectedDeleveryDate);
                    cmd.Parameters.AddWithValue("UReciverLocation", UpdatedOrder.ExpectedDeleveryDate);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    return RowsAffected;
                }
            }
        }

        public static int Add(OrderDTO NewOrder)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Orders_AddNewOrder", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("OrderDetails", NewOrder.OrderDetails);
                    cmd.Parameters.AddWithValue("OrderPrice", NewOrder.Price);
                    cmd.Parameters.AddWithValue("PaymentStatus", NewOrder.PaymentStatus);
                    cmd.Parameters.AddWithValue("PaymentMethod", NewOrder.PayamentMethod);
                    cmd.Parameters.AddWithValue("ReciverName", NewOrder.RecieverName);
                    cmd.Parameters.AddWithValue("Weight", NewOrder.Weight);
                    cmd.Parameters.AddWithValue("ReciverPhone", NewOrder.RecieverPhone);
                    cmd.Parameters.AddWithValue("CustomerID", NewOrder.CustomerID);
                    cmd.Parameters.AddWithValue("DriverID", NewOrder.DriverID);
                    cmd.Parameters.AddWithValue("AreaID", NewOrder.AreaID);
                    cmd.Parameters.AddWithValue("ExpectedDeliveryDate", NewOrder.ExpectedDeleveryDate);
                    cmd.Parameters.AddWithValue("SenderLocation", NewOrder.SenderLocation);
                    cmd.Parameters.AddWithValue("ReciverLocation", NewOrder.ReciverLocation);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;

                }
            }
        }
    }
}
