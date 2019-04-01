using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class BrojGodinaController : Controller
    {
        // GET: BrojGodina
        public ViewResult RacunajBrojGodina()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RacunajBrojGodina(DateTime datum)
        {
            int brojGodina;
            try
            {
                brojGodina = (DateTime.Now - datum).Days / 365;
                return View((object)brojGodina.ToString());


            }
            catch (Exception e){
                return View((object)e.Message);
            }
        }
    }
}