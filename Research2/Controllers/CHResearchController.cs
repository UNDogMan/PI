using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Research2.Controllers
{
    public class CHResearchController : Controller
    {
        [OutputCache(Duration = 5)]
        public ActionResult AD()
        {
            return Content(DateTime.Now.ToString());
        }

        [OutputCache(Duration = 7)]
        public ActionResult AP(int x, int y)
        {
            return Content($"{x + y} {DateTime.Now}");
        }
    }
}