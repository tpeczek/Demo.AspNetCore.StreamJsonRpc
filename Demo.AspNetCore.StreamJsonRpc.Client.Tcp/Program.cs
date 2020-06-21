using System.IO;
using System.Text;
using System.Net.Sockets;
using StreamJsonRpc;
using Demo.AspNetCore.StreamJsonRpc.Contract;
using System.Threading.Tasks;
using System;

namespace Demo.AspNetCore.StreamJsonRpc.Client.Tcp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost", 6000);

            Stream jsonRpcStream = tcpClient.GetStream();
            IJsonRpcMessageFormatter jsonRpcMessageFormatter = new JsonMessageFormatter(Encoding.UTF8);
            IJsonRpcMessageHandler jsonRpcMessageHandler = new LengthHeaderMessageHandler(jsonRpcStream, jsonRpcStream, jsonRpcMessageFormatter);

            IGreeter jsonRpcGreeterClient = JsonRpc.Attach<IGreeter>(jsonRpcMessageHandler);

            HelloReply helloReply = await jsonRpcGreeterClient.SayHelloAsync(new HelloRequest { Name = "Tomasz Pęczek" });

            Console.WriteLine(helloReply.Message);

            jsonRpcStream.Close();

            Console.ReadKey();
        } 
    }
}