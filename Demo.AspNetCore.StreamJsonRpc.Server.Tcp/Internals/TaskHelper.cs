using System.Threading;
using System.Threading.Tasks;

namespace Demo.AspNetCore.StreamJsonRpc.Server.Tcp.Internals
{
    internal static class TaskHelper
    {
        internal static Task WaitAsync(this CancellationToken cancellationToken)
        {
            TaskCompletionSource<bool> cancelationTaskCompletionSource = new TaskCompletionSource<bool>();
            cancellationToken.Register(CancellationTokenCallback, cancelationTaskCompletionSource);

            return cancellationToken.IsCancellationRequested ? Task.CompletedTask : cancelationTaskCompletionSource.Task;
        }

        private static void CancellationTokenCallback(object taskCompletionSource)
        {
            ((TaskCompletionSource<bool>)taskCompletionSource).SetResult(true);
        }
    }
}
