using System;
using System.ComponentModel;
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
        [Description("任务名称")]
        public string TaskName { get; set; }
        [Description("开始时间")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Description("结束时间")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }

        //public virtual Employee Employee { get; set; }
        [Description("任务名称")]
        public string TName { get { return TaskName.Length > 15 ? TaskName.Substring(0, 15) + "..." : TaskName; } }

    }
}
