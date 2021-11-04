using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Context;

namespace WebApplication1.Data
{
    public class WebApp1DBInitializer
    {
        private readonly WebStoreDB _db;
        private readonly ILogger<WebApp1DBInitializer> _Logger;

        public WebApp1DBInitializer(WebStoreDB db, ILogger<WebApp1DBInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public async Task InitializeAsync()
        {
            _Logger.LogInformation("Запуск инициализации БД");
            //var db_deleted = await _db.Database.EnsureDeletedAsync();
            //var dv_created= await _db.Database.EnsureCreatedAsync();

            IEnumerable<string> pending_migrations = await _db.Database.GetPendingMigrationsAsync();
            var applied_migrations = await _db.Database.GetAppliedMigrationsAsync();

            if(pending_migrations.Any())
            {
                _Logger.LogInformation($"Применение миграций: {0}", string.Join(",", pending_migrations));
                await _db.Database.MigrateAsync();
            }

            await InitializeProductAsync();
        }

        private async Task InitializeProductAsync()
        {
            var timer = Stopwatch.StartNew();

            if(_db.Sections.Any())
            {
                _Logger.LogInformation("Инициализация БД информацией о товарах не требуется");
                return;
            }

            var sections_pool = TestData.Sections.ToDictionary(section => section.Id);
            var brands_pool = TestData.Brands.ToDictionary(brand => brand.Id);

            foreach (var child_section in TestData.Sections.Where(s => s.ParentId is not null))
                child_section.Parent = sections_pool[(int)child_section.ParentId!];

            foreach (var product in TestData.Products)
            {
                product.Section = sections_pool[product.SectionId];
                if (product.BrandId is { } brand_id)
                    product.Brand = brands_pool[brand_id];

                product.Id = 0;
                product.SectionId = 0;
                product.BrandId = null;
            }

            foreach (var section in TestData.Sections)
            {
                section.Id = 0;
                section.ParentId = 0;
            }

            foreach (var brand in TestData.Brands)
                brand.Id = 0;


            _Logger.LogInformation("Запись продукции...");
            await using(await _db.Database.BeginTransactionAsync())
            {
                _db.Products.AddRange(TestData.Products);
                _db.Brands.AddRange(TestData.Brands);

                await _db.SaveChangesAsync();
                await _db.Database.CommitTransactionAsync();
            }
            _Logger.LogInformation($"Запись продукции выполнена успешно за {0} мс", timer.Elapsed.TotalMilliseconds);
        }
    }
}
