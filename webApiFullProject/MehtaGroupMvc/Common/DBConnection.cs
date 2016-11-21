using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehtaGroupMvc.Common
{
    public static class DBConnection
    {
        public static string Connectionstring
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString; }
        }
    }
}