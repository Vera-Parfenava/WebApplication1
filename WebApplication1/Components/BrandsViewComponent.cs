﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Components
{
    //[ViewComponent(Name = "BrandsView")]
    public class BrandsViewComponent:ViewComponent
    {
        // public async Task<IViewComponentResult> InvokeAsync() => View();
         public IViewComponentResult  Invoke() => View();

    }
}
