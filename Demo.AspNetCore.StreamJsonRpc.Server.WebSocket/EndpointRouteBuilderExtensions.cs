using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Demo.AspNetCore.StreamJsonRpc.Server.WebSocket
{
    internal static class EndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapStreamJsonRpc(this IEndpointRouteBuilder endpoints, string pattern)
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            RequestDelegate pipeline = endpoints.CreateApplicationBuilder()
               .UseMiddleware<StreamJsonRpcMiddleware>()
               .Build();

            return endpoints.Map(pattern, pipeline);
        }
    }
}
