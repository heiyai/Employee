using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

#nullable disable

namespace Employee.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Tasks = new HashSet<Task>();
        }
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HiredDate { get; set; }

        //public List<Task> Tasks { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public string FName { get { return FirstName.Length > 5 ? FirstName.Substring(0, 5) + "..." : FirstName; } }
        public string LName { get { return LastName.Length > 5 ? LastName.Substring(0, 5) + "..." : LastName; } }
    }
}
