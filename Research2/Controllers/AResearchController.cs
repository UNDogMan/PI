using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Research2.Controllers
{
    public class AResearchController : Controller
    {
        [ActionAttribute]
        public ActionResult AA()
        {
            return Content("AA");
        }

        [ResultAttribute]
        public ActionResult AR()
        {
            return Content("AR");
        }

        [ExeptionAttribute]
        public ActionResult AE()
        {
            throw new Exception("AE");
        }
    }

    public class ActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p><em>OnActionExecuted</em></p>");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p><em>OnActionExecuting</em></p>");
        }
    }

    public class ResultAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p><em>OnResultExecuted</em></p>");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p><em>OnResultExecuted</em></p>");
        }
    }

    public class ExeptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p><em>OnException</em></p> ");
            filterContext.HttpContext.Response.Write(filterContext.Exception.Message);
            filterContext.ExceptionHandled = true;
        }
    }
}