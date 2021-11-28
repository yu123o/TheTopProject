using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TheTopProject.Models
{
    public partial class Design
    {
        public Design()
        {
            Cart = new HashSet<Cart>();
            Offer = new HashSet<Offer>();
            Review = new HashSet<Review>();
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Cost { get; set; }
        public string Image { get; set; }
        public int CategroyId { get; set; }
        public int CustomerId { get; set; }
        public DateTime AddDate { get; set; }
        [NotMapped]
        [DisplayName("Advertisement")]
        public IFormFile ImageFile { get; set; }
        public virtual Category Categroy { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
