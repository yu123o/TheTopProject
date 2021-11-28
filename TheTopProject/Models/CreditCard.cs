using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TheTopProject.Models
{
    public partial class CreditCard
    {
        public decimal Number { get; set; }
        public double Balance { get; set; }
    }
}
