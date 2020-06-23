using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StreamJsonRpc;

namespace Demo.AspNetCore.StreamJsonRpc.Server.WebSocket
{
    internal class StreamJsonRpcMiddleware
    {
        public StreamJsonRpcMiddleware(RequestDelegate next)
        { }

        public async Task Invoke(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await context.WebSockets.AcceptWebSocketAsync();

                IJsonRpcMessageHandler jsonRpcMessageHandler = new WebSocketMessageHandler(webSocket);

                using (var jsonRpc = new JsonRpc(jsonRpcMessageHandler, new GreeterServer()))
                {
                    jsonRpc.StartListening();

                    await jsonRpc.Completion;
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
