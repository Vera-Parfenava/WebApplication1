using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    [Route("guests")]
    public class GuestsController : Controller
    {
        private readonly IGuestsData _guestsData;
        private readonly ILogger<GuestsController> _logger;
        public GuestsController(IGuestsData guestsData, ILogger<GuestsController> logger)
        {
            _guestsData = guestsData;
            _logger = logger;
        }
        public IActionResult Index() => View(_guestsData.GetAll());

        /// <summary>
        /// Details about guests
        /// </summary>
        /// <param name="id"> guest Id</param>
        /// <returns></returns>
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var guest = _guestsData.GetById(id);
            if (guest is null)
                {
                return NotFound();
                }
            return View(guest);
        }
        ///<summary>
        ///Add and edit a guest
        ///</summary>
        ///<param name= "id"></param>
        ///<returns></returns>
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            GuestsView model;
            if(id.HasValue)
            {
                model = _guestsData.GetById(id.Value);
                if (model is null)
                {
                    return NotFound();
                }
                
            }
            else
            {
                model = new GuestsView();
            }
            return View(model);
           
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(GuestsView model)
        {
            if (model.Id > 0)
            {
                var dbItem = _guestsData.GetById(model.Id);
                if (dbItem is null)
                {
                    return NotFound();
                }
                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Partronymic = model.Partronymic;
                dbItem.Relation = model.Relation;
                dbItem.Side = model.Side;
            }
            else
            {
                _guestsData.AddNew(model);
            }
            _guestsData.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}

