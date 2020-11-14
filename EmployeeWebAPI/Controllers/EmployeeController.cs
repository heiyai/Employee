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

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            
            var emp = _iEmployeeService.Find<Employee.Model.Employee>(id);
            if (emp == null)
                return app.Tag.Failed;
            emp.Tasks = _iTaskService.Query<Employee.Model.Task>(x => x.EmployeeId == emp.EmployeeId).ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(emp);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public HttpResponseMessage Post(string value)
        {
            var response = new HttpResponseMessage();
            Employee.Model.Employee employee = JsonConvert.DeserializeObject<Employee.Model.Employee>(value);
            var entity = _iEmployeeService.Insert<Employee.Model.Employee>(employee);
            if (entity == null || entity.EmployeeId <= 0)
                response.StatusCode = HttpStatusCode.BadRequest;
            else
                response.StatusCode = HttpStatusCode.OK;
            return response;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public HttpResponseMessage Put(int id, string value)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            Employee.Model.Employee employee = JsonConvert.DeserializeObject<Employee.Model.Employee>(value);
            employee.EmployeeId = id;
            _iEmployeeService.Update<Employee.Model.Employee>(employee);
            return response;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;

            try
            {
                _iEmployeeService.Delete<Employee.Model.Employee>(id);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }
            return response;
        }
    }
}
