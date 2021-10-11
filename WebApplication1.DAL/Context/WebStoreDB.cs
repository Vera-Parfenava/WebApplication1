using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Domain.Entities;


namespace WebApplication1.DAL.Context
{
    public class WebStoreDB: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }


        public WebStoreDB(DbContextOptions<WebStoreDB> options): base(options) { }

        //protected override void OnModelCreating(ModelBuilder model)
        //{
        //    base.OnModelCreating(model);

        //    /*model.Entity<Section>;*/
        //}
    }
}
