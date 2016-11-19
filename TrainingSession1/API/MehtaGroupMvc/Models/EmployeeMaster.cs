using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehtaGroupMvc.Models
{
    public class EmployeeMaster
    {
        public DataSet GetEmployeeData()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(DBConnection.Connectionstring, CommandType.StoredProcedure, "GetEmployee");
            }
            catch (Exception)
            {

                throw;
            }

            return ds;
        }


        public int AddEmployee(string empFirstName, string empLastName, string empDesignation, string empLatLong, string empPassword)
        {
            int result = 0;
            try
            {
                SqlParameter IsSave = new SqlParameter("@IsSaved", SqlDbType.Int);
                IsSave.Direction = ParameterDirection.Output;

                result = SqlHelper.ExecuteNonQuery(DBConnection.Connectionstring, CommandType.StoredProcedure, "SaveEmployee",
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