using System.Net.Http.Formatting;
using MehtaGroupMvc.Common;
using MehtaGroupMvc.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;

namespace MehtaGroupMvc.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeMaster objEmp = new EmployeeMaster();
        string JSON = string.Empty;

        [HttpGet]
        public HttpResponseMessage GetEmployee()
        {

            HttpResponseMessage response = new HttpResponseMessage();
            DataSet ds = new DataSet();
            try
            {
                ds = objEmp.GetEmployeeData();

                // JSON = ds.DataSetToJSON();

                var data = ds.DataSetToJSON();
                response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(data, Encoding.UTF8, "application/json");

            }
            catch (Exception e)
            {
                throw;
            }

            return response;

        }

        [HttpPost]
        public HttpResponseMessage AddEmployee(FormDataCollection frm)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string empFirstName = frm.Get("empFirstName");
                string empLastName = frm.Get("empLastName");
                string empDesignation = frm.Get("empDesignation");
                string empLatLong = frm.Get("empLatLong");
                string empPassword = frm.Get("empPassword");

                int result = objEmp.AddEmployee(empFirstName, empLastName, empDesignation, empLatLong, empPassword);

                //var data = result.DataSetToJSON();
                response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(Convert.ToString(result), Encoding.UTF8, "application/json");

            }
            catch (Exception e)
            {
                throw;
            }

            return response;

        }
    }
}
