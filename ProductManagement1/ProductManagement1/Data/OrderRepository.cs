using ProductManagement1.Interfaces;
using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Data
{
    public class OrderRepository : IOrderRepository<Order>
    {
        string cs;
        SqlConnection con = null;
        public OrderRepository()
        {
            //cs = ConfigurationManager.Connection
            cs = @"Server = .; Database =ProductManagement; User ID = sa; Password =123456";
        }
        public void createOrder(Order order)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("insert into " +
                  "dbo.tblOrder(CustomerName,Address,Price,OrderDate,Status)" +
                  " values(@CustomerName,@Address,@Price,@OrderDate,@Status)", con);
                    cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    cmd.Parameters.AddWithValue("@Address", order.Address);
                    cmd.Parameters.AddWithValue("@Price", order.Price);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@Status", order.Status);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void createOrder(string customerName, string address)
        {
            throw new NotImplementedException();
        }

        public void deleteOrder(int id)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Delete from dbo.tblOrder where Id=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Order> searchOrderByCustomerName(string customerName)
        {
            List<Order> list = new List<Order>();
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Select" +
                    " Id,CustomerName,Address,Price,OrderDate,Status " +
                    "from dbo.tblOrder" +
                    " where CustomerName = @CustomerName", con);
                cmd.Parameters.AddWithValue("@CustomerName", customerName);
                con.Open();
                using (SqlDataReader rs = cmd.ExecuteReader())
                {
                    while (rs.Read())
                    {
                        list.Add(new Order(
                            rs.GetInt32("Id"),
                            rs.GetString("CustomerName"),
                            rs.GetString("Address"),
                            rs.GetDouble("Price"),
                            rs.GetDateTime("OrderDate"),
                            rs.GetInt32("Status")));
                    }
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return list;
        }


        public List<Order> GetOrderById(int Id)
        {
            con = new SqlConnection(cs);
            List<Order> list = new List<Order>();
            try
            {
                SqlCommand cmd = new SqlCommand(@"Select" +
                    " Id,CustomerName,Address,Price,OrderDate,Status " +
                    "from dbo.tblOrder" +
                    " where Id = @Id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Id", Id);
                using (SqlDataReader rs = cmd.ExecuteReader())
                {
                    while (rs.Read())
                    {
                        list.Add(new Order(
                            rs.GetInt32("Id"),
                            rs.GetString("CustomerName"),
                            rs.GetString("Address"),
                            rs.GetDouble("Price"),
                            rs.GetDateTime("OrderDate"),
                            rs.GetInt32("Status")));
                    }
                }
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return list;

        }


        public List<Order> Get()
        {
            List<Order> list = new List<Order>();
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("Select" +
                    " Id,CustomerName,Address,Price,OrderDate,Status " +
                    "from dbo.tblOrder", con);
                con.Open();
                using (SqlDataReader rs = cmd.ExecuteReader())
                {
                    while (rs.Read())
                    {
                        list.Add(new Order(
                            rs.GetInt32("Id"),
                            rs.GetString("CustomerName"),
                            rs.GetString("Address"),
                            rs.GetDouble("Price"),
                            rs.GetDateTime("OrderDate"),
                            rs.GetInt32("Status")));
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return list;
        }
        public void updateOrder(string customerName, string address,int OrderId)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.tblOrder" +
                      " SET CustomerName = @CustomerName," +
                      " Address = @Address" +
                      " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Id", OrderId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void updateOrderPrice(int OrderId)
        {
            OrderDetailRepository oDetailRepository = new OrderDetailRepository();
            List<OrderDetail> oDetailList = oDetailRepository.GetOrderDetailsByOrderId(OrderId);
            double price = 0;
            foreach (OrderDetail oDetail in oDetailList)
            {
                price += oDetail.Price;
            }
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.tblOrder" +
                      " SET Price = @Price" +
                      " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Id", OrderId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void updateOrderStatus(int orderId, int status)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.tblOrder" +
                      " SET Status = @Status" +
                      " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Id", orderId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
