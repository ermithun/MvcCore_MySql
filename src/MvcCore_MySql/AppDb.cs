using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore_MySql
{
    public class AppDb : IDisposable
    {

        public MySqlConnection Connection;

        public AppDb()
        {
            Connection = new MySqlConnection(AppConfig.Config["Data:ConnectionString"]);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
