using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PayCoin.Client.Client;
using PayCoin.Client.Services;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PayCoin.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services
                .AddBlazoredLocalStorage()
                .AddBlazoredLocalStorage(config =>
                {
                    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    config.JsonSerializerOptions.IgnoreNullValues = true;
                    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                    config.JsonSerializerOptions.WriteIndented = false;
                })
                 .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IChildCategoryService, ChildCategoryService>()
                .AddScoped<ISmallCategoryService, SmallCategoryService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IProviderService, ProviderService>()
                .AddScoped<ICommunityService, CommunityService>()
                .AddScoped<ICouponService, CouponService>()
                 .AddScoped<UserClient>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            var host = builder.Build();
            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();
            await host.RunAsync();
        }
    }
}
