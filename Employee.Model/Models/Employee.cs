using System;
using System.Collections.Generic;

#nullable disable

namespace Employee.Model
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }

        public string FName { get { return FirstName.Length > 5 ? FirstName.Substring(0, 5) + "..." : FirstName; } }
        public string LName { get { return LastName.Length > 5 ? LastName.Substring(0, 5) + "..." : LastName; } }
    }
}
