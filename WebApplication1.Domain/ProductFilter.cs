using System;
using System.Collections.Generic;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain;


namespace WebApplication1.Domain
{
    public class ProductFilter
    {
        public int? SectionId { get; set; }
        public int? BrandId { get; set; }

    }
}
