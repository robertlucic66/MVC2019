using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5_5_vj.Models;

namespace _5_5_vj.Controllers
{
    public class ListaArtikalaController : Controller
    {
        //// GET: ListaArtikala
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult UnesiArtikal()
        {
            ViewBag.Kategorije = new string[]
            {
                "Alati", "Tehnika", "Prehrambeni proizvodi"
                
        };
            return View(new Artikal());

        }

        [HttpPost]
        public ActionResult DodajArtikal(Artikal artikal)
        {
            if (Session["Artikli"] != null)
            {
                List<Artikal> artikli = (List<Artikal>)Session["Artikli"];
                artikli.Add(artikal);
                Session["Artikli"] = artikli;
            }
            else
            {
                List<Artikal> artikli = new List<Artikal>();
                artikli.Add(artikal);
                Session["Artikli"] = artikli;
            }
            return View(Session["Artikli"]);
        }
    }
}