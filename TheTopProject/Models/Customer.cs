using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TheTopProject.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cart = new HashSet<Cart>();
            Design = new HashSet<Design>();
            Review = new HashSet<Review>();
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        [DisplayName("First Name")]
        public string Fname { get; set; }
        [DisplayName("Last Name")]
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Design> Design { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
