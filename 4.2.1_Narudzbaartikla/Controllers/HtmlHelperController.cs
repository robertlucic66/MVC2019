using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace _4._2._1_Narudzbaartikla.Controllers
{
    public class HtmlHelperController : Controller
    {
        // GET: HtmlHelper
        public ActionResult Index()
        {
            return View();
        }

        private string[] mjesta = new string[]
        {
            "Split", "Osijek", "Zadar", "Rijeka"
        };
        

        public ViewResult FormHelper()
        {
            ViewBag.Mjesta = this.mjesta;
            return View(new Osoba());
        }

        [HttpPost]
        public ViewResult FormHelper(Osoba osoba)
        {
            ViewBag.Mjesta = this.mjesta;
            ViewBag.Poruka = "Podaci su unešeni!";
            return View(new Osoba());
        }

        public ViewResult StrongTypedFormHelper()
        {
            ViewBag.Mjesta = this.mjesta;
            return View(new Osoba());
        }

        [HttpPost]
        public ViewResult StrongTypedFormHelper(Osoba osoba)
        {
            ViewBag.Mjesta = this.mjesta;
            ViewBag.Poruka = "Podaci su unešeni";
            return View(new Osoba());
        }

    }
}