using Employee.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee.Model.Employee> Get()
        {
            return this._iEmployeeService.Set<Employee.Model.Employee>();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var emp = _iEmployeeService.Find<Employee.Model.Employee>(id);
            emp.Tasks = _iTaskService.Query<Employee.Model.Task>(x => x.EmployeeId == emp.EmployeeId).ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(emp);
            
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
