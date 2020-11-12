using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Model
{
    [Serializable]
    [Table("Employee")]
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
        public ICollection<Task> EmployeeTaskList { get; set; }

        public State State { get; set; }
    }
}
