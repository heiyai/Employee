﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Employee.Model
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }

        public virtual Employee Employee { get; set; }

        public string TName { get { return TaskName.Length > 15 ? TaskName.Substring(0, 15) + "..." : TaskName; } }
        
    }
}
