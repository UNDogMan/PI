using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Research.Controllers
{
    public class CResearchController : Controller
    {
        // GET: CResearch
        public ActionResult C01()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("C01");
            if(Request.Params.Count > 0)
            {
                sb.AppendLine("Params : ");
                foreach(var key in Request.Params.AllKeys)
                {
                    sb.AppendLine($"\t{key} - {Request.Params.GetValues(key).FirstOrDefault()}");
                }
            }
            sb.Append("Uri :").AppendLine(Request.Url.AbsoluteUri);
            sb.AppendLine("Headers:");
            foreach(var key in Request.Headers.AllKeys)
            {
                sb.AppendLine($"\t{key} - {Request.Headers.GetValues(key).FirstOrDefault()}");
            }
            if(Request.HttpMethod == "POST")
            {
                using (var stream = new StreamReader(Request.InputStream))
                    sb.AppendLine(stream.ReadToEnd());
            }
            return Content(sb.ToString());
        }

        public ActionResult C02()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("C02");
            sb.AppendLine($"Ansver Code: {Response.StatusCode}");
            sb.AppendLine("Headers:");
            foreach (var key in Request.Headers.AllKeys)
            {
                sb.AppendLine($"\t{key} - {Request.Headers.GetValues(key).FirstOrDefault()}");
            }
            if (Request.HttpMethod == "POST")
            {
                using (var stream = new StreamReader(Request.InputStream))
                    sb.AppendLine(stream.ReadToEnd());
            }
            return Content(sb.ToString());
        }
    }
}