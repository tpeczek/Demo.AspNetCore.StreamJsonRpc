using System.Threading.Tasks;

namespace Demo.AspNetCore.StreamJsonRpc.Contract
{
    public interface IGreeter
    {
        Task<HelloReply> SayHelloAsync(HelloRequest request);
    }
}
