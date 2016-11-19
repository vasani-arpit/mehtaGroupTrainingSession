using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehtaGroupMvc.Common
{
    public static class JsonConvert
    {

        public static string DataSetToJSON(this DataSet ds)
        {
            object[] dict = new object[ds.Tables.Count];

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                DataTable dt = ds.Tables[i];

                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                dict[i] = rows;
            }

            System.Web.Script.Serialization.JavaScriptSerializer json = new System.Web.Script.Serialization.JavaScriptSerializer();
         
            return json.Serialize(dict);
        }
    }
}