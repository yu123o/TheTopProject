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
    public partial class Category
    {
        public Category()
        {
            Design = new HashSet<Design>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime DateofAdd { get; set; }
        [NotMapped]
        [DisplayName("Category")]
        public IFormFile ImageFile { get; set; }
        public virtual ICollection<Design> Design { get; set; }
    }
}
