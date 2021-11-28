using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TheTopProject.Models
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string TaskContent { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime FinishTime { get; set; }
        public bool? Done { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
