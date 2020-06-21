using System.Threading.Tasks;
using Demo.AspNetCore.StreamJsonRpc.Contract;

namespace Demo.AspNetCore.StreamJsonRpc.Server
{
    public class GreeterServer : IGreeter
    {
        public Task<HelloReply> SayHelloAsync(HelloRequest request)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
