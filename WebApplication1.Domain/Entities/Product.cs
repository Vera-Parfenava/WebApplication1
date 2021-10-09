using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities
{
    class Product
    {
        public int Order { get; set; }
        public int SectionId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

    }
}
