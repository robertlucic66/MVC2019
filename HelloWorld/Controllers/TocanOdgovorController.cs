using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class TocanOdgovorController : Controller
    {
        // GET: TocanOdgovor
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ProvjeriOdgovor(string Odgovor)
        {
            string rezultat;
            if (!string.IsNullOrEmpty(odgovor))
            {
                if (Odgovor = "Bruxelles")
                {
                    rezultat = "Odgovor je točan";
                    return View((object)rezultat)
;
                }
                else
                {
                    rezultat = "Odgovor nije točan!";
                    return View((object)rezultat);
                }
            }


        }
    }
}