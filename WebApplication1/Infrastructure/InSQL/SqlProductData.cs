using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Context;
using WebApplication1.Domain;
using WebApplication1.Domain.Entities;
using WebApplication1.Infrastructure.Interfaces;

namespace WebApplication1.Infrastructure.InSQL
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreDB _db;

        public SqlProductData(WebStoreDB db) => _db = db;

        IEnumerable<Brand> IProductData.GetBrands() => _db.Brands;

        IEnumerable<Product> IProductData.GetProducts(ProductFilter Filter)
        {
            IQueryable<Product> query = _db.Products;
            
            if (Filter?.SectionId is { } section_id)
                query = query.Where(p => p.SectionId == section_id);

            if (Filter?.BrandId is { } brand_id)
                query = query.Where(p => p.SectionId == brand_id);

            return query;
        }

        IEnumerable<Section> IProductData.GetSections() => _db.Sections;
    }
}
