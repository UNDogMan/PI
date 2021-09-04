using System;
using System.IO;
using System.Web;

namespace HttpHandlers
{
    public class IISHandler2 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    DoGet(context);
                    break;
                case "POST":
                    DoPost(context);
                    break;
            }
        }

        private void DoGet(HttpContext context)
        {
            context.Response.Write(File.ReadAllText(@"D:\box\PI\HttpHandlers\HtmlPage.html"));
        }

        private void DoPost(HttpContext context)
        {
            int X = int.Parse(context.Request.Params.Get(0));
            int Y = int.Parse(context.Request.Params.Get(1));
            context.Response.Write(X + Y);
        }

        #endregion
    }
}
