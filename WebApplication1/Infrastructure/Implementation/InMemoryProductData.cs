using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infrastructure.Implementation;
using WebApplication1.Domain.Entities;
using WebApplication1.Data;




namespace WebApplication1.Infrastructure
{
    public class InMemoryProductData: IProductData
    {
        public IEnumerable<Section> GetSections() => TestData.Sections;
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

    }
}
