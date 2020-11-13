using Employee.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Employee.Model;

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
        public void Post([FromBody] string value)
        {
            Employee.Model.Employee employee = JsonConvert.DeserializeObject<Employee.Model.Employee>(value);

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Employee.Model.Employee employee = JsonConvert.DeserializeObject<Employee.Model.Employee>(value);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _iTaskService.DeleteByEmployeeID<Task>(id);
            _iEmployeeService.Delete<Employee.Model.Employee>(id);

            return app.Tag.Successufl;
        }
    }
}
