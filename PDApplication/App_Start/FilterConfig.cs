using PDApplication.Filters;
using System.Web;
using System.Web.Mvc;

namespace PDApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new NotFoundExeptionFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
