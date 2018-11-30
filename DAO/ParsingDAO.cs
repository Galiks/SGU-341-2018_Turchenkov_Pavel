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
    public class ParsingDAO : IParsingDAO
    {
        private readonly string _connectionString;

        public ParsingDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["parsing"].ConnectionString;
        }

        public int AddData(AbstractSite site, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddShop";

                var name = new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = site.Name
                };

                var discount = new SqlParameter("@Discount", SqlDbType.VarChar)
                {
                    Value = site.Discount
                };

                var url = new SqlParameter("@Url", SqlDbType.VarChar)
                {
                    Value = site.Url
                };

                var image = new SqlParameter("@Image", SqlDbType.VarChar)
                {
                    Value = site.Image
                };

                var dateAdd = new SqlParameter("@DateAdd", SqlDbType.VarChar)
                {
                    Value = site.Date_add
                };

                var idSite = new SqlParameter("@SiteID", SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.AddRange(new SqlParameter[] { name, discount, url, image, dateAdd, idSite });

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
                command.CommandText = "AddSite";

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
            throw new NotImplementedException();
        }

        //public IEnumerable<LetyShops> GetDiscounts()
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var command = connection.CreateCommand();

        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "ShowAllDiscounts";

        //        connection.Open();

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                yield return new LetyShops
        //                {
        //                    Name = (string)reader["Description"],
        //                    Discount = (string)reader["Discount_percent"],
        //                    Url = "url",
        //                    Image = "image",
        //                    Date_add = (string)reader["Data_add"],
        //                };
        //            }
        //        }

        //    }
        //}
    }
}
