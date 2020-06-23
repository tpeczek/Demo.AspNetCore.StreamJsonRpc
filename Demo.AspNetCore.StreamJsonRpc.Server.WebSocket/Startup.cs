using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.AspNetCore.StreamJsonRpc.Server.WebSocket
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapStreamJsonRpc("/json-rpc-greeter");
                })
                .Run(async (context) =>
                {
                    await context.Response.WriteAsync("-- Demo.AspNetCore.StreamJsonRpc.Server.WebSocket --");
                });
        }
    }
}
