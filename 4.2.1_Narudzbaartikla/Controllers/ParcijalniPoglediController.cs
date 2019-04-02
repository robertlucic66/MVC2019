using _4._2._1_Narudzbaartikla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4._2._1_Narudzbaartikla.Controllers
{
    public class ParcijalniPoglediController : Controller
    {
        // GET: ParcijalniPogledi
        public ActionResult PrikaziKosaricu()
        {
            List<Artikal> listaArtikala = new List<Artikal>()
            {
                new Artikal()
                {
                    Cijena=9.99m, Kategorija="plava", Kolicina=5, Naziv="Keks"
                },
                 new Artikal()
                {
                    Cijena=8.99m, Kategorija="zelena", Kolicina=5, Naziv="Kifla"
                },
                  new Artikal()
                {
                    Cijena=5.99m, Kategorija="zuta", Kolicina=5, Naziv="Kroki"
                }

            };
            return View(listaArtikala);
        }
    }
}