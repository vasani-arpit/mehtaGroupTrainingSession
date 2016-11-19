using System.Net.Http.Formatting;
using MehtaGroupApi2.Models;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;

namespace MehtaGroupApi2.Controllers
{
    public class EmployeeController : ApiController
    {

        DataSet ds = new DataSet();
        string JSON;
        EmployeeMaster objEmp = new EmployeeMaster();
        [HttpGet]
        public HttpResponseMessage GetEmployee()
        {
            HttpResponseMessage objresponce = new HttpResponseMessage();

            try
            {
                ds = objEmp.EmployeeDataFromSQl();
                

                var data = ds.DataSetToJSON();
                objresponce = this.Request.CreateResponse(HttpStatusCode.OK);
                objresponce.Content = new StringContent(data, Encoding.UTF8, "application/json");

            }
            catch (Exception)
            {

                throw;
            }
            return objresponce;
        }

        [HttpPost]
        public HttpResponseMessage InsertEmployee(FormDataCollection frm)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            string Firsname = frm.Get("EmpFirstName");
            string LastName = frm.Get("EmpLastName");
            string deg = frm.Get("EmpDesignation");
            string latlong = frm.Get("LatLong");
            string Password = frm.Get("password");

            int val = 0;
            try
            {
                 val =  objEmp.InserEmployeeData(Firsname, LastName, deg, latlong, Password);

                 response = this.Request.CreateResponse(HttpStatusCode.OK, new { IsSaved = Convert.ToString(val) });
            }
            catch (Exception)
            {
                
                throw;
            }
            return response;

        }

    }
}
