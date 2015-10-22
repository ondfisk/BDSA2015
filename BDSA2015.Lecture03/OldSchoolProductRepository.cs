using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BDSA2015.Lecture03
{
    public class OldSchoolProductRepository : IProductRepository
    {
        private readonly SqlConnection _connection;

        public OldSchoolProductRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Product> Read()
        {
            var sql = "SELECT ProductID, ProductName, UnitPrice FROM Products ORDER BY ProductID";

            using (var command = new SqlCommand(sql, _connection))
            {
                _connection.Open();
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            Id = (int)reader["ProductID"],
                            Name = reader["ProductName"] as string,
                            Price = (decimal)reader["UnitPrice"]
                        };

                        yield return product;
                    }
                }
            }
        }

        public Product Read(int productId)
        {
            var sql = "SELECT ProductID, ProductName, UnitPrice FROM Products WHERE ProductID = @ProductID";

            using (var command = new SqlCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);

                _connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    var product = new Product
                    {
                        Id = (int)reader["ProductID"],
                        Name = reader["ProductName"] as string,
                        Price = (decimal)reader["UnitPrice"]
                    };

                    return product;
                }
            }
        }

        public int Create(Product product)
        {
            var sql = "INSERT Products (ProductName, UnitPrice) VALUES (@ProductName, @UnitPrice); SELECT SCOPE_IDENTITY()";

            using (var command = new SqlCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@ProductName", product.Name);
                command.Parameters.AddWithValue("@UnitPrice", product.Price);

                _connection.Open();

                var id = (int) command.ExecuteScalar();

                return id;
            }
        }

        public void Update(Product product)
        {
            var sql = "UPDATE Products SET ProductName = @ProductName, UnitPrice = @UnitPrice WHERE ProductID = @ProductID";

            using (var command = new SqlCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@ProductID", product.Id);
                command.Parameters.AddWithValue("@ProductName", product.Name);
                command.Parameters.AddWithValue("@UnitPrice", product.Price);

                _connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int productId)
        {
            var sql = "DELETE WHERE ProductID = @ProductID";

            using (var command = new SqlCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);

                _connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
