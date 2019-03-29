using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class SimpleBindingController : Controller
    {
        public ViewResult SimpleBindMetoda()
        {
            return View("SimpleBindMetoda");
        }

        [HttpPost]

        public ViewResult SimpleBindMetoda(string ime)
        {
            string pozdrav = "Pozdrav, " + ime + "!";
            return View("SimpleBindMetoda", (object)pozdrav);
        }

    }
}