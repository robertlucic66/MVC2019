using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4._2._1_Narudzbaartikla.Models;

namespace _4._2._1_Narudzbaartikla.Controllers
{
    public class NarudzbaArtiklaController : Controller
    {
        // GET: NarudzbaArtikla
        public ViewResult NaruciArtikal()
        {
            return View(new Artikal());
        }

        [HttpPost]
        public ViewResult NaruciArtikal(Artikal artikal)
        {
            if(artikal.Kolicina > 10)
            {
                ViewBag.Poruka = "Nema dovoljno " + artikal.Naziv + " na skladištu!";
                return View(artikal);
            }
            else
            {
                ViewBag.Poruka = "Naručeno je " +
                    artikal.Kolicina +
                    " komada " +
                    artikal.Naziv +
                    " sa ukupnom cijenom " +
                    artikal.Cijena * artikal.Kolicina;
                return View(artikal);
            }
        }

    }
}