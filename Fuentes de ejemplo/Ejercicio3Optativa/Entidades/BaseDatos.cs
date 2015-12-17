using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Entidades
{
    public static class BaseDatos
    {
        public static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());


    }
}
