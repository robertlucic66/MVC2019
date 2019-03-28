using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class KontekstController : Controller
    {
        // GET: Kontekst
        public string Index()
        {
            string poruka = "Danas je: " + DateTime.Now.ToLongDateString();
            return poruka;
        }

        public string QueryPodaci()
        {
            if (Request.QueryString["Ime"] == null || Request.QueryString["Prezime"] == null)
            {
                return "Podaci su nepotpuni!";
            }
            else
            {
                string ime = Request.QueryString["Ime"];
                string prezime = Request.QueryString["Prezime"];
                string tekstSaStilom = string.Format("<label style='color:red; font-weight:bold;'>{0} {1}</label>",
                    ime, prezime);
                return string.Format("<p>Ime i prezime iz query stringa su: {0}</p>", tekstSaStilom);

            }
        }
        public string RoutePodaci()
        {
            try
            {
                string kontroler = RouteData.Values["controller"].ToString();
                string akcijskaMetoda = RouteData.Values["action"].ToString();
                string parametarId = RouteData.Values["id"].ToString();
                return "<h1>Route podaci:</h1>" +
                    "kontroler: " + kontroler + "<br/>" +
                    "Metoda: " + akcijskaMetoda + "<br/>" +
                    "Parametar Id: " + parametarId + "<br/>";
            }catch(Exception e)
            {
                return "Došlo je do pogreške: " + e.Message;
            }


        }
    }
}