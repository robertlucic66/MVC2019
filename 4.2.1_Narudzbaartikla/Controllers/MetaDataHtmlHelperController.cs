using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4._2._1_Narudzbaartikla.Models;

namespace _4._2._1_Narudzbaartikla.Controllers
{
    public class MetaDataHtmlHelperController : Controller
    {
        // GET: TemplHtmlHelperi
        public ViewResult MetaDataView()
        {
            return View(new OsobaMeta());
        }

        [HttpPost]
        public ViewResult MetaDataView(OsobaMeta osoba)
        {
            return View("HtmlLabelDisplay", osoba);
        }


    }
}