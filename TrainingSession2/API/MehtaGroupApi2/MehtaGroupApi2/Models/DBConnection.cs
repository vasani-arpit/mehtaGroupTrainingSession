using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehtaGroupApi2.Models
{
    public static class DBConnection
    {
        public static string Connection {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString; }
        }
    }
}