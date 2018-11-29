using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LetyShopsDAO : ILetyShopsDAO
    {
        private readonly string _connectionString;

        public LetyShopsDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["parsing"].ConnectionString;
        }

        public int AddData(LetyShops letyShops, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddDiscount";

                var name = new SqlParameter("@Description", SqlDbType.VarChar)
                {
                    Value = letyShops.Name
                };

                command.Parameters.Add(name);

                var dataAdd = new SqlParameter("@Data_add", SqlDbType.DateTime)
                {
                    Value = letyShops.Date_add
                };

                command.Parameters.Add(dataAdd);

                var discount = new SqlParameter("@Discount_persent", SqlDbType.Float)
                {
                    Value = letyShops.Discount
                };

                command.Parameters.Add(discount);

                var idShop = new SqlParameter("@id_shop", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(idShop);

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public int AddShop(Shop shop)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddShop";

                var name = new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = shop.Name
                };

                command.Parameters.Add(name);

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public IEnumerable<LetyShops> GetDiscounts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ShowAllDiscounts";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new LetyShops
                        {
                            Name = (string)reader["Description"],
                            Discount = (string)reader["Discount_percent"],
                            Url = "url",
                            Image = "image",
                            Date_add = (string)reader["Data_add"],
                        };
                    }
                }

            }
        }
    }
}
