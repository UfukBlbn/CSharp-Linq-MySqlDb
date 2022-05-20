using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace VeritabanıMySql
{
    public interface IProductDal
    {
       List<Product> GetAllProducts();

       Product GetProductById(int id);
       List<Product> Find(string productName);

       int Count();

       int Create(Product p);
       void Update(Product p);
       void Delete(int productId);
    }

    public class MySQLProductDal : IProductDal
    {
        
        //MySql Bağlantı Metodu
        private MySqlConnection GetMySqlConnection()
        {
            string connectionString = @"server=localhost;port=3306;database=northwind;user=root;password=Blbnlr.123;";
            return new MySqlConnection(connectionString);
        
        }
        public int Create(Product p)
        {
            int result = 0;
            using ( var connection = GetMySqlConnection())
            {

                try{
                    connection.Open();
                    
                    string sql = "insert into products (product_name,list_price,Discontinued) values(@productname,@unitprice,@discontinued) ";
                    
                    MySqlCommand command = new MySqlCommand(sql,connection);

                    command.Parameters.AddWithValue("@productname" , p.ProductName);
                    command.Parameters.AddWithValue("@unitprice" , p.ProductPrice);
                    command.Parameters.AddWithValue("@discontinued", 1);
                    
                    //result değişkenine kaç adet kayıt eklendiği bilgisi gelir
                    result = command.ExecuteNonQuery();

                    Console.WriteLine($"{result} adet kayıt eklendi");
                
                     
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            return result;
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
           List<Product> products = null;
            
             using ( var connection = GetMySqlConnection())
            {

                try{
                    connection.Open();
                    
                    string sql = "select * from products";
                    
                    MySqlCommand command = new MySqlCommand(sql,connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    //Sınıf ismi ile aynı olmalı
                     products = new List<Product>();
                    
                    while(reader.Read())
                    {  
                        products.Add
                        (
                            new Product
                            {
                                ProductId=int.Parse(reader[1].ToString()),
                                ProductName=reader["product_name"].ToString(),
                                ProductPrice=double.Parse(reader["list_price"]?.ToString())
                            });
                    } 
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = null;

             using ( var connection = GetMySqlConnection())
            {

                try{
                    connection.Open();
                    
                    string sql = "select * from products where id=@productid";
                    
                    MySqlCommand command = new MySqlCommand(sql,connection);
                    command.Parameters.Add("@productid",MySqlDbType.Int32).Value=id;

                    MySqlDataReader reader = command.ExecuteReader();
                    
                    reader.Read();

                    if(reader.HasRows)
                    {
                        product = new Product()
                        {
                            ProductId=int.Parse(reader[1].ToString()),
                            ProductName=reader["product_name"].ToString(),
                            ProductPrice=double.Parse(reader["list_price"]?.ToString())
                        };
                    }
                    //Sınıf ismi ile aynı olmalı
                     
                   
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            
            return product;
        }

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }

        public List<Product> Find(string productName)
        {
            
             List<Product> products = null;
            
             using ( var connection = GetMySqlConnection())
            {

                try{
                    connection.Open();
                    
                    string sql = "select * from products where product_name LIKE @ProductName ";
                    
                    MySqlCommand command = new MySqlCommand(sql,connection);
                    command.Parameters.Add("@ProductName",MySqlDbType.String).Value="%"+productName+"%";

                    MySqlDataReader reader = command.ExecuteReader();

                    //Sınıf ismi ile aynı olmalı
                     products = new List<Product>();
                    
                    while(reader.Read())
                    {  
                        products.Add
                        (
                            new Product
                            {
                                ProductId=int.Parse(reader[1].ToString()),
                                ProductName=reader["product_name"].ToString(),
                                ProductPrice=double.Parse(reader["list_price"]?.ToString())
                            });
                    } 
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }

        public int Count()
        {
            int count=0;
            
             using ( var connection = GetMySqlConnection())
            {

                try{
                    connection.Open();
                    
                    string sql = "select count(*) from products";
                    
                    MySqlCommand command = new MySqlCommand(sql,connection);
                    
                    // Null bir değer gelme ihtimaline karşı burada nesne içerisine kaydettik.
                    object result = command.ExecuteScalar();
                    if(result!=null)
                    {
                         count = Convert.ToInt32(result);
                    }
                   

                    //Sınıf ismi ile aynı olmalı
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return count;
        }


    }

    public class MsSQLProductDal : IProductDal
    {
        private SqlConnection GetMsSqlConnection()
        {
            string connectionString = @"";
            return new SqlConnection(connectionString);
        
        }
        public void Create(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = null;
            
             using ( var connection = GetMsSqlConnection())
            {

                try{
                    connection.Open();
                    
                    string sql = "select * from products";
                    
                    SqlCommand command = new SqlCommand(sql,connection);

                    SqlDataReader reader = command.ExecuteReader();

                    //Sınıf ismi ile aynı olmalı
                     products = new List<Product>();
                    
                    while(reader.Read())
                    {  
                        products.Add
                        (
                            new Product
                            {
                                ProductId=int.Parse(reader[1].ToString()),
                                ProductName=reader["product_name"].ToString(),
                                ProductPrice=double.Parse(reader["list_price"]?.ToString())
                            });
                    } 
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }

        public List<Product> Find(string productName)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        int IProductDal.Create(Product p)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductManager : IProductDal
    {
        IProductDal  _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal=productDal;
        }

        public int Count()
        {
            return _productDal.Count();
        }


        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> Find(string productName)
        {
            return _productDal.Find(productName);
        }

        public List<Product> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productDal.GetProductById(id);

        }

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }

        public int Create(Product p)
        {
            return _productDal.Create(p);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          var productDal = new ProductManager(new MySQLProductDal());
          var p = new Product()
          {
              ProductName = "Xiaomi Mi Band 4 ",
              ProductPrice = 12000
          };

          int count = productDal.Create(p);

          //var products = productDal.Find("Northwind");
          //int count=productDal.Count();
          Console.WriteLine($"Total Products : {count}");
        //    foreach (var pr in products)
        //    {
        //        Console.WriteLine($"Product Id : {pr.ProductId} Name : {pr.ProductName}");
        //    }

        }
        
    }
}
