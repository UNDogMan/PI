using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDApplication.Filters
{
    public class NotFoundExeptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is HttpException ex &&
                ex.ErrorCode == 404)
            {
                string actionName = (string)filterContext.RouteData.Values["action"];
                var res = new ViewResult
                {
                    ViewName = "NotFound",
                    ViewData = new ViewDataDictionary()
                };
                res.ViewData["action"] = actionName;
                filterContext.Result = res;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}