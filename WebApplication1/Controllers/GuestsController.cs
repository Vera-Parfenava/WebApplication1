using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.ViewModel;
using WebApplication1.Models;






namespace WebApplication1.Controllers
{
    [Route("guests")]
    public class GuestsController : Controller
    {
        private readonly IGuestsData _GuestsData;
        private readonly ILogger<GuestsController> _Logger;
        public GuestsController(IGuestsData GuestsData, ILogger<GuestsController> Logger)
        {
            _GuestsData = GuestsData;
            _Logger = Logger;
        }
        public IActionResult Index() => View(_GuestsData.GetAll());

        /// <summary>
        /// Details about guests
        /// </summary>
        /// <param name="id"> guest Id</param>
        /// <returns></returns>
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var guest = _GuestsData.GetById(id);
            if (guest is null)
            {
                return NotFound();
            }
            return View(guest);
        }
        #region Edit
        ///<summary>
        ///Edit a guest
        ///</summary>
        ///<param name= "id"></param>
        ///<returns></returns>
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {

            var guest = _GuestsData.GetById(id.Value);
            if (guest is null)
            {
                return NotFound();
            }

            var model = new GuestsViewModel()
            {
                FirstName = guest.FirstName,
                Id = guest.Id,
                SurName = guest.SurName,
                Partronymic = guest.Partronymic,
                Age = guest.Age,
                Relation = guest.Relation,
                Side = guest.Side
            };

            return View(model);

        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(GuestsViewModel model)
        {
            var guest = new GuestsView()
            {
                FirstName = model.FirstName,
                Id = model.Id,
                SurName = model.SurName,
                Partronymic = model.Partronymic,
                Age = model.Age,
                Relation = model.Relation,
                Side = model.Side
            };

            _GuestsData.UpDate(guest);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        ///<summary>
        ///Delete a guest
        ///</summary>
        ///<param name= "id"></param>
        ///<returns></returns>
        [Route("del/{id?}")]
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var guest = _GuestsData.GetById(id);
            //if (guest is null)
            //{
            //    return NotFound();
            //}
            return View(
            new GuestsViewModel()
            {
                Id = guest.Id,
                SurName = guest.SurName,
                FirstName = guest.FirstName,
                Partronymic = guest.Partronymic,
                Age = guest.Age,
                Relation = guest.Relation,
                Side = guest.Side
            });
        }

        [HttpPost]
        [Route("del/{id?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _GuestsData.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

