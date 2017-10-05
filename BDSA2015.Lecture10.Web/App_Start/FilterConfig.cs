using System.Web;
using System.Web.Mvc;

namespace BDSA2015.Lecture10.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
