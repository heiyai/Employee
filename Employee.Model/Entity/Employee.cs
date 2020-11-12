using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee.Model
{
    [Serializable]
    public class Employee : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime HiredDate { get; set; }
        public List<EmployeeTask> EmployeeTaskList { get; set; }

        public State State { get; set; }
    }
}
