using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Interfaces;


namespace WebApplication1.Controllers
{
    [Route("guests")]
    public class GuestsController : Controller
    {
        private readonly IGuestsData _guestsData;
        public GuestsController(IGuestsData guestsData)
        {
            _guestsData = guestsData;
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
    }
}

