using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevExtreme_DemoApp.Models;
using DevExtreme.AspNet.Data;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace DevExtreme_DemoApp.Controllers
{
    public class EmployeController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetEmploye(DataSourceLoadOptions loadOptions)
        {
            return Request.CreateResponse(DataSourceLoader.Load(SampleData._Employee, loadOptions));
        }

        [HttpDelete]
        public void Delete(FormDataCollection _EmpForm)
        {
            Int64 EmpID = Convert.ToInt32(_EmpForm.Get("key"));
            var itemToRemove = SampleData._Employee.SingleOrDefault(r => r.EmpID == EmpID);
            SampleData._Employee.Remove(itemToRemove);
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection _EmpForm)
        {
            var newEmp = new Employee();
            JsonConvert.PopulateObject(_EmpForm.Get("values"), newEmp);
            newEmp.EmpID = SampleData._Employee.Max(r => r.EmpID) + 1;

            SampleData._Employee.Add(newEmp);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection _EmpForm)
        {
            var editEmp = new Employee();
            Int64 EmpID = Convert.ToInt32(_EmpForm.Get("key"));
            JsonConvert.PopulateObject(_EmpForm.Get("values"), editEmp);

            var itemToUpdate = SampleData._Employee.SingleOrDefault(r => r.EmpID == EmpID);
            itemToUpdate.EmpName = String.IsNullOrEmpty(editEmp.EmpName)? itemToUpdate.EmpName : editEmp.EmpName;
            itemToUpdate.EmpAddress = String.IsNullOrEmpty(editEmp.EmpAddress) ? itemToUpdate.EmpAddress : editEmp.EmpAddress;
            itemToUpdate.EmpDob = String.IsNullOrEmpty(editEmp.EmpDob.ToString()) ? itemToUpdate.EmpDob : editEmp.EmpDob;
            itemToUpdate.EmpEmail = String.IsNullOrEmpty(editEmp.EmpEmail) ? itemToUpdate.EmpEmail : editEmp.EmpEmail;
            itemToUpdate.EmpSalery = String.IsNullOrEmpty(editEmp.EmpSalery.ToString()) ? itemToUpdate.EmpSalery : editEmp.EmpSalery;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage GetEmployeSalery()
        {
            return Request.CreateResponse(SampleData._Employee.Select(m=>new {arg=m.EmpName,val=m.EmpSalery }));
        }
    }
}
