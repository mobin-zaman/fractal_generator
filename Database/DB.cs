using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace fractal_generator.Database
{
    class DB
    {

        public static void ExecuteSql(String sql)
        {

            var dbCon = DBConnection.Instance();
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = sql;
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("READER: " + reader.GetType());
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                dbCon.Close();
                Console.WriteLine(reader);
            }
        }
    }
}
