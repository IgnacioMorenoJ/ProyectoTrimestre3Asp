using System.Web;
using System.Web.Mvc;

namespace ProyectoTrimestre3Asp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
