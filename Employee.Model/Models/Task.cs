using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Employee.Model
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        [MaxLength(50)]
        [Required]
        public string TaskName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }

        //public virtual Employee Employee { get; set; }

        public string TName { get { return TaskName.Length > 15 ? TaskName.Substring(0, 15) + "..." : TaskName; } }

    }
}
