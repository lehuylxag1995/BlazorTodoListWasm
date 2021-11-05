using Blazored.Toast;
using BlazorTodoListWasm.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTodoListWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddHttpClient("WebAPI", client =>
            //    client.BaseAddress = new Uri("https://localhost:5001"));

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress =
                new Uri(builder.Configuration["URLWebApi"])
            });

            builder.Services.AddBlazoredToast();

            builder.Services.AddTransient<ITodoService, TodoService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ITodoUserService, TodoUserService>();

            await builder.Build().RunAsync();
        }
    }
}
