using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Research2.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        [HttpGet]
        [Route("{n:long}/{str}")]
        public ActionResult M01(long n, string str)
        {
            return Content($"{Request.HttpMethod}:M01:/{n}/{str}");
        }

        [Route("{b:bool}/{letters:alpha}")]
        [AcceptVerbs("GET", "POST")]
        public ActionResult M02(bool b, string letters)
        {
            return Content($"{Request.HttpMethod}:M02:/{b}/{letters}");
        }

        [Route("{f:float}/{str:length(2, 5)}")]
        [AcceptVerbs("GET", "DELETE")]
        public ActionResult M03(float f, string str)
        {
            return Content($"{Request.HttpMethod}:M03:/{f}/{str}");
        }

        [Route("{letters:alpha}/{n:range(100, 200)}")]
        [HttpPut]
        public ActionResult M04(string letters, int n)
        {
            return Content($"{Request.HttpMethod}:M04:/{letters}/{n}");
        }

        [Route("{mail:regex(^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$)}")]
        [HttpPost]
        public ActionResult M04(string mail)
        {
            return Content($"{Request.HttpMethod}:M04:/{mail}");
        }
    }
}