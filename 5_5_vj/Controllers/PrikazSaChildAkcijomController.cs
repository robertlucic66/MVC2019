using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5_5_vj.Models;

namespace _5_5_vj.Controllers
{
    public class PrikazSaChildAkcijomController : Controller
    {
        // GET: PrikazSaChildAkcijom
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObradiListu()
        {
            List<Artikal> listaArtikala = new List<Artikal>
            {
                new Artikal("Samsung Galaxy S10+", 7499.99m, "Tehnika"),
                new Artikal("Čokolada", 21.99m, "Prehrambeni proizvodi"),
                new Artikal("Bušilica", 889.99m, "Alati")
            };
            return View(listaArtikala);
        }

        [ChildActionOnly]
        public string OdrediKategoriju(Artikal artikal)
        {
            return artikal.Kategorija;
        }
    }
}