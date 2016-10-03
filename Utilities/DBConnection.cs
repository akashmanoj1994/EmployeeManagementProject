using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Utilities
{
    public static class DBConnection
    {
        public static SqlConnection GetConnection(string connectionname)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionname].ConnectionString);
            return connection;
        }
    }
}
