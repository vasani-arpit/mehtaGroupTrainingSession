using System.Data.SqlClient;
using MehtaGroupMvc.Common;
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

        public DataSet GetEmployeeDataByID(int empID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = SqlHelper.ExecuteDataset(DBConnection.Connectionstring, CommandType.StoredProcedure, "GetEmployeeByID", new SqlParameter("@EmpID", empID));
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        public int AddEmployee(string empFirstName, string empLastName, string empDesignation, string empLatLong, string empPassword, string empImage)
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
                    new SqlParameter("@EmpImage", empImage),
                    IsSave);

                result = Convert.ToInt32(IsSave.Value);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public int UpdateEmployee(string empFirstName, string empLastName, string empDesignation, string empLatLong, string empPassword, string empImage, int empID)
        {
            int result = 0;
            try
            {
                SqlParameter IsSave = new SqlParameter("@IsSaved", SqlDbType.Int);
                IsSave.Direction = ParameterDirection.Output;

                result = SqlHelper.ExecuteNonQuery(DBConnection.Connectionstring, CommandType.StoredProcedure, "UpdateEmployee",
                    new SqlParameter("@EmpID", empID),
                    new SqlParameter("@EmpFirstName", empFirstName),
                    new SqlParameter("@EmpLastName", empLastName),
                    new SqlParameter("@EmpDesignation", empDesignation),
                    new SqlParameter("@LatLong", empLatLong),
                    new SqlParameter("@Password", empPassword),
                    new SqlParameter("@EmpImage", empImage),
                    IsSave);

                result = Convert.ToInt32(IsSave.Value);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public int DeleteEmployee(int empID)
        {
            int result = 0;
            try
            {
                SqlParameter IsSave = new SqlParameter("@IsSaved", SqlDbType.Int);
                IsSave.Direction = ParameterDirection.Output;

                result = SqlHelper.ExecuteNonQuery(DBConnection.Connectionstring, CommandType.StoredProcedure, "DeleteEmployee",
                    new SqlParameter("@EmpID", empID),
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