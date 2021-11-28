using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TheTopProject.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ReviewText { get; set; }
        public double CompanyRatio { get; set; }
        public int DesignId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Design Design { get; set; }
    }
}
