using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace fractal_generator.Database
{
    class DB
    {

        public static  MySqlDataReader ExecuteSql(String sql)
        {

            var dbCon = DBConnection.Instance();
            MySqlDataReader reader = null;
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = sql;
                var cmd = new MySqlCommand(query, dbCon.Connection);
                reader = cmd.ExecuteReader();
            }
            return reader;
        }
    }
}
