using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MehtaGroupMvc.Common
{
    public static class JSONSerialization
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

        //public static string GetJSON(this string uri)
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        Task<String> response = httpClient.GetStringAsync(uri);
        //        return JsonConvert.DeserializeObjectAsync<Dictionary<String, object>>(response.Result).Result;
        //    }
        //}
    }
}