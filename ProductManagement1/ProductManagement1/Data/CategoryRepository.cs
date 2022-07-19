using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement1.Models;

namespace ProductManagement1.Data
{
    public class CategoryRepository
    {
        string cs;
        SqlConnection con = null;
       
        public CategoryRepository()
        {
            //cs = ConfigurationManager.Connection
            cs = @"Server = .; Database =ProductManagement; User ID = sa; Password =123456";
        }
        public List<Category> Get()
        {
            con = new SqlConnection(cs);
            List<Category> list = new List<Category>();
            try
            {
                SqlCommand cmd = new SqlCommand("Select Id,CategoryName,Status from dbo.Category", con);
                con.Open();

                using (SqlDataReader rs = cmd.ExecuteReader())
                {
                    while (rs.Read())
                    {
                        list.Add(new Category(rs.GetInt32("Id"), rs.GetString("CategoryName"), rs.GetInt32("Status")));
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


        public List<Category> GetName(string CategoryName)
        {
            con = new SqlConnection(cs);
            List<Category> list = new List<Category>();
            try
            {
                SqlCommand cmd = new SqlCommand(@"Select Id,CategoryName,Status from dbo.Category WHERE CategoryName LIKE @CategoryName", con);
                con.Open();
                cmd.Parameters.AddWithValue("@CategoryName", "%" + CategoryName + "%");
                using (SqlDataReader rs = cmd.ExecuteReader())
                {
                    while (rs.Read())
                    {
                        list.Add(new Category(rs.GetInt32("Id"), rs.GetString("CategoryName"), rs.GetInt32("Status")));
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



        public Category GetByName(string CategoryName)
        {
            con = new SqlConnection(cs);
            Category cate = new Category();
            try
            {
                SqlCommand cmd = new SqlCommand(@"Select Id,CategoryName,Status from dbo.Category WHERE CategoryName LIKE @CategoryName", con);
                con.Open();
                cmd.Parameters.AddWithValue("@CategoryName", "%" + CategoryName + "%");
                using (SqlDataReader rs = cmd.ExecuteReader())
                {
                    while (rs.Read())
                    {
                        cate = new Category(rs.GetInt32("Id"),
                            rs.GetString("CategoryName"), 
                            rs.GetInt32("Status"));
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
            return cate;

        }
        public void Delete(int id)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Delete from dbo.Category where Id=@Id", con);
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

        public void deleteByName(string name)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("Delete from dbo.Category where CategoryName=@CategoryName", con);
                    cmd.Parameters.AddWithValue("@CategoryName", name);
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
        public void Add(Category p)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("insert into " +
                   "dbo.Category(CategoryName,Status)" +
                   " values(@CategoryName,@Status)", con);
                    cmd.Parameters.AddWithValue("@CategoryName", p.CategoryName);
                    cmd.Parameters.AddWithValue("@Status", p.Status);

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


        public void AddUpdate(Category p)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("insert into " +
                   "dbo.Category(Id,CategoryName,Status)" +
                   " values(@Id,@CategoryName,@Status)", con);
                    cmd.Parameters.AddWithValue("Id", p.Id);
                    cmd.Parameters.AddWithValue("@CategoryName", p.CategoryName);
                    cmd.Parameters.AddWithValue("@Status", p.Status);

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

        public void Update(int id, Category p)
        {
            try
            {
                con = new SqlConnection(cs);
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE dbo.Category" +
                        " SET CategoryName = @CategoryName," +
                        " Status= @Status," +
                        " WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("@CategoryName", p.CategoryName);
                    cmd.Parameters.AddWithValue("@Status", p.Status);
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
    }
}
