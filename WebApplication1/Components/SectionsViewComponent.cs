using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Components
{
    public class BrandViewComponent:ViewComponent
    {
        // public async Task<IViewComponentResult> InvokeAsync() => View();
        public IViewComponentResult Invoke() => View();

    }
}
