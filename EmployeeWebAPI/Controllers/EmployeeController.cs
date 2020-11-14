using Employee.Interface;
using EmployeeWebAPI.Utility.Filter;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace EmployeeWebAPI.Controllers
{
    using E = Employee.Model.Employee;
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _iEmployeeService = null;
        private ITaskService _iTaskService = null;
        public EmployeeController(IEmployeeService employeeService, ITaskService taskService)
        {
            this._iEmployeeService = employeeService;
            this._iTaskService = taskService;
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {

            var emp = _iEmployeeService.Find<Employee.Model.Employee>(id);
            if (emp == null)
                return app.Tag.Failed;
            emp.Tasks = _iTaskService.Query<Employee.Model.Task>(x => x.EmployeeId == emp.EmployeeId).ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(emp);
        }

        
        [HttpPost]
        public HttpResponseMessage Post(string value)
        {
            var response = new HttpResponseMessage();
            E employee = JsonConvert.DeserializeObject<E>(value);
            var entity = _iEmployeeService.Insert<E>(employee);
            if (entity == null || entity.EmployeeId <= 0)
                response.StatusCode = HttpStatusCode.BadRequest;
            else
                response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        
        [HttpPut]
        public HttpResponseMessage Put(int id, string value)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            E employee = JsonConvert.DeserializeObject<E>(value);
            employee.EmployeeId = id;
            _iEmployeeService.Update<E>(employee);
            return response;
        }

        
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;


            _iEmployeeService.Delete<E>(id);


            return response;
        }
    }
}
