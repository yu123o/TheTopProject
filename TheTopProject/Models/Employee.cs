using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TheTopProject.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Deduction = new HashSet<Deduction>();
            EmployeeAttendence = new HashSet<EmployeeAttendence>();
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        [DisplayName("Full Name")]
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public string JobTitle { get; set; }
        public string DepartmentName { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime StartWorkTime { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Deduction> Deduction { get; set; }
        public virtual ICollection<EmployeeAttendence> EmployeeAttendence { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
