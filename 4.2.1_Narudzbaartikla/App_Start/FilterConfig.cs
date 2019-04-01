using System.Web;
using System.Web.Mvc;

namespace _4._2._1_Narudzbaartikla
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
