using System;
using System.Linq;
using System.Text;
using System.Web;

namespace HttpHandlers
{
    public class IISHandler1 : IHttpHandler
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
            StringBuilder sb = new StringBuilder();
            sb.Append(context.Request.HttpMethod).Append("-Http-ZRU:");
            foreach(var paramKey in context.Request.Params.AllKeys.Where(x => x.Contains("Param")))
            {
                sb.Append(paramKey).Append("=").Append(context.Request.Params.GetValues(paramKey.ToString()).First()).Append(",");
            }
            context.Response.Write(sb.ToString());
        }

        #endregion
    }
}
