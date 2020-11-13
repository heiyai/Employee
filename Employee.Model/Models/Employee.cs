using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Employee.Model
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        [Description("名")]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Description("姓")]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [Description("录取日期")]
        [DataType(DataType.DateTime)]
        public DateTime HiredDate { get; set; }

        [Description("名")]
        public string FName { get { return FirstName.Length > 5 ? FirstName.Substring(0, 5) + "..." : FirstName; } }
        [Description("姓")]
        public string LName { get { return LastName.Length > 5 ? LastName.Substring(0, 5) + "..." : LastName; } }
    }
}
