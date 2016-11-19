using MehtaGroupApi2.Models;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MehtaGroupApi2.Models
{
    public class EmployeeMaster
    {
        public DataSet EmployeeDataFromSQl()
        {

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(DBConnection.Connection, CommandType.StoredProcedure, "GetEmployee");
            return ds;
        }

        public int InserEmployeeData(string empFirstName, string empLastName, string empDesignation, string empLatLong, string empPassword)
        {
            int result = 0;

            try
            {
                SqlParameter IsSave = new SqlParameter("@IsSaved", SqlDbType.Int);
                IsSave.Direction = ParameterDirection.Output;

                result = SqlHelper.ExecuteNonQuery(DBConnection.Connection, CommandType.StoredProcedure, "SaveEmployee",
                    new SqlParameter("@EmpFirstName", empFirstName),
                    new SqlParameter("@EmpLastName", empLastName),
                    new SqlParameter("@EmpDesignation", empDesignation),
                    new SqlParameter("@LatLong", empLatLong),
                    new SqlParameter("@Password", empPassword),
                    IsSave);

                result = Convert.ToInt32(IsSave.Value);
            }
            catch (Exception)
            {
                
                throw;
            }

            return result;
        }

        

    }
}