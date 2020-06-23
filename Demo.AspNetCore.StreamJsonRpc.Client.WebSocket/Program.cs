using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using StreamJsonRpc;
using Demo.AspNetCore.StreamJsonRpc.Contract;

namespace Demo.AspNetCore.StreamJsonRpc.Client.WebSocket
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var webSocket = new ClientWebSocket())
            {
                await webSocket.ConnectAsync(new Uri("ws://localhost:5000/json-rpc-greeter"), CancellationToken.None);

                IJsonRpcMessageHandler jsonRpcMessageHandler = new WebSocketMessageHandler(webSocket);

                IGreeter jsonRpcGreeterClient = JsonRpc.Attach<IGreeter>(jsonRpcMessageHandler);

                HelloReply helloReply = await jsonRpcGreeterClient.SayHelloAsync(new HelloRequest { Name = "Tomasz Pęczek" });

                Console.WriteLine(helloReply.Message);

                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closing", CancellationToken.None);
            }

            Console.ReadKey();
        }
    }
}
