using System;
using System.Collections.Generic;

#nullable disable

namespace Employee.Model.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }
        public byte State { get; set; }
    }
}
