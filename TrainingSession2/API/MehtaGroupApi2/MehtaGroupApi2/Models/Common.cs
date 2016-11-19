using System.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehtaGroupApi2.Models
{
    public static class Common
    {

        public static string DataSetToJSON(this DataSet ds)
        {
            string result = string.Empty;
            result = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return result;
        }

        public static string DataTableToJSON(this DataTable dt)
        {
            string result = string.Empty;
            result = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return result;
        }

    }
}