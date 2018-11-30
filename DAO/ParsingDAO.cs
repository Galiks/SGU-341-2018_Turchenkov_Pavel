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

        public int AddShop(AbstractShop shop)
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

                var discount = new SqlParameter("@Discount", SqlDbType.Float)
                {
                    Value = shop.Discount
                };

                var url = new SqlParameter("@Url", SqlDbType.VarChar)
                {
                    Value = shop.Url
                };

                var image = new SqlParameter("@Image", SqlDbType.VarChar)
                {
                    Value = shop.Image
                };

                var dateAdd = new SqlParameter("@DateAdd", SqlDbType.DateTime)
                {
                    Value = shop.Date_add
                };

                var idSite = new SqlParameter("@SiteID", SqlDbType.Int)
                {
                    Value = shop.IdSite
                };

                command.Parameters.AddRange(new SqlParameter[] { name, discount, url, image, dateAdd, idSite });

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public int AddSite(Site site)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddSite";

                var name = new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = site.Name
                };

                command.Parameters.Add(name);

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public IEnumerable<AbstractShop> GetShopByDiscount(double shopDiscount)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetShopByDiscount";

                var discount = new SqlParameter("@Discount", SqlDbType.Float)
                {
                    Value = shopDiscount
                };

                command.Parameters.Add(discount);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Shop
                        {
                            IdSite = (int)reader["id_site"],
                            Name = (string)reader["Name"],
                            Discount = (double)reader["Discount"],
                            Url = (string)reader["Url_on_site"],
                            Image = (string)reader["Image"],
                            Date_add = (DateTime)reader["Date_add"],
                            IdShop = (int)reader["id"]
                        };
                    }
                }
            }
        }

        public IEnumerable<AbstractShop> GetShopByName(string shopName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetShopByName";

                var name = new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = shopName
                };

                command.Parameters.Add(name);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Shop
                        {
                            IdSite = (int)reader["id_site"],
                            Name = (string)reader["Name"],
                            Discount = (double)reader["Discount"],
                            Url = (string)reader["Url_on_site"],
                            Image = (string)reader["Image"],
                            Date_add = (DateTime)reader["Date_add"],
                            IdShop = (int)reader["id"]
                        };
                    }
                }
            }
        }

        public IEnumerable<AbstractShop> GetShops()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllShop";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Shop
                        {
                            IdSite = (int)reader["id_site"],
                            Name = (string)reader["Name"],
                            Discount = (double)reader["Discount"],
                            Url = (string)reader["Url_on_site"],
                            Image = (string)reader["Image"],
                            Date_add = (DateTime)reader["Date_add"],
                            IdShop = (int)reader["id"]
                        };
                    }
                }
            }
        }

        public IEnumerable<AbstractShop> GetShopsBySite(int siteID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetShopsBySiteID";

                var id = new SqlParameter("@SiteID", SqlDbType.Int)
                {
                    Value = siteID
                };

                command.Parameters.Add(id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Shop
                        {
                            IdSite = (int)reader["id_site"],
                            Name = (string)reader["Name"],
                            Discount = (double)reader["Discount"],
                            Url = (string)reader["Url_on_site"],
                            Image = (string)reader["Image"],
                            Date_add = (DateTime)reader["Date_add"],
                            IdShop = (int)reader["id"]
                        };
                    }
                }
            }
        }

        public Site GetSiteByID(int siteID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetSiteByID";

                var id = new SqlParameter("@SiteID", SqlDbType.Int)
                {
                    Value = siteID
                };

                command.Parameters.Add(id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Site
                        {
                            IdSite = (int)reader["id"],
                            Name = (string)reader["Name"],
                        };
                    }
                }
            }

            return null;
        }

        public Site GetSiteByName(string siteName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetSiteByName";

                var name = new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = siteName
                };

                command.Parameters.Add(name);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Site
                        {
                            IdSite = (int)reader["id"],
                            Name = (string)reader["Name"],
                        };
                    }
                }
            }

            return null;
        }

        public IEnumerable<Site> GetSites()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllSite";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Site
                        {
                            IdSite = (int)reader["id"],
                            Name = (string)reader["Name"],
                        };
                    }
                }
            }
        }

        public int UpdateSite(int siteID, string siteName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateSite";

                var id = new SqlParameter("@SiteID", SqlDbType.Int)
                {
                    Value = siteID
                };

                var name = new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = siteName
                };

                command.Parameters.AddRange(new SqlParameter[] { id, name });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }
    }
}
