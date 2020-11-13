using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Service;
using Employee.Interface;
using Employee.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _iTaskService = null;
        public TaskController(ITaskService taskService)
        {
            this._iTaskService = taskService;
        }
        // GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<Employee.Model.Task> Get()
        {
            //return new string[] { "value1", "value2" };
            return this._iTaskService.Set<Employee.Model.Task>();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
