using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InMemoryWebApi.Models;

namespace InMemoryWebApi.Data
{
    public class DataAccess
    {
        private static SqlConnection Connection => new SqlConnection("");

        public static IEnumerable<Value> ValuesSelect()
        {
            var results = new List<Value>();

            using (var connection = Connection)
            using (var cmd = new SqlCommand("[dbo].[ValuesSelect]", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        results.Add(new Value
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Data = Convert.ToString(reader["Data"]),
                        });
                    }

            }

            return results;
        }

        public static void ValuesInsert(string data)
        {
            using (var connection = Connection)
            using (var cmd = new SqlCommand("[dbo].[ValuesInsert]", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@data", data));

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}