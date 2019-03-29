using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class OsobeController : Controller
    {
        // GET: Osobe/PopuniOsobu
        public ActionResult PopuniOsobu()
        {
            return View();
        }

        // POST: Osobe/PopuniOsobu
        [HttpPost]
        public ActionResult PrikaziOsobu(Osoba osoba)
        {
            return View(osoba);
        }


    }
}