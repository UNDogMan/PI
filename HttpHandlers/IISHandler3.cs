using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace HttpHandlers
{
    public class IISHandler3 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler
        WebSocket _socket;
        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
        }

        private async Task WebSocketRequest(AspNetWebSocketContext arg)
        {
            _socket = arg.WebSocket;
            string s = await Receive();
            await Send(s);
            int i = 0;
            while (_socket.State == WebSocketState.Open)
            {
                System.Threading.Thread.Sleep(1000);
                await Send($"[{i++}]");
            }
        }

        private async Task<string> Receive()
        {
            string rc = null;
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await _socket.ReceiveAsync(buffer, CancellationToken.None);
            rc = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
            return rc;
        }

        private async Task Send(string s)
        {
            var sendBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Ответ: " + s));
            await _socket.SendAsync(sendBuffer, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
        }
        #endregion
    }
}
