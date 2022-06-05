using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataAccess.Helpers
{
    class SqlHelper
    {
        static public SqlConnection GetConnection()
        {
            SqlConnection cnn = new SqlConnection("Server=.;Database=ChatDB;User Id=aydin;Password=123");
            cnn.Open();
            return cnn;
        }
    }
}
