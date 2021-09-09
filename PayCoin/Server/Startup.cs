using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PayCoin.Server.Data;
using PayCoin.Server.Infrastructure;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Repositorys;
using PayCoin.Server.Requests;
using PayCoin.Server.Services;
using System;
using System.Linq;
using System.Text;

namespace PayCoin.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PayCoinContext>(options =>
                               options.UseSqlServer(Configuration.GetConnectionString("PayCoinContext")));
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();
            //JWT Config
            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            services.AddControllers().AddNewtonsoftJson(options =>
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
   );
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ShouldBeOnlyAdminOrEditor", policy =>
                      policy.RequireClaim("AdminId"));
                options.AddPolicy("ShouldBeOnlyUser", policy =>
                     policy.RequireClaim("UserId"));
                options.AddPolicy("ShouldBeOnlyProvider", policy =>
                     policy.RequireClaim("ProviderId"));
                options.AddPolicy("ShouldBeOnlyDelivery", policy =>
                     policy.RequireClaim("DeliveryId"));
                options.AddPolicy("ShouldBeOnlyCommunity", policy =>
                     policy.RequireClaim("CommunityId"));
                options.AddPolicy("ShouldBeOnlyDesigner", policy =>
                     policy.RequireClaim("DesignerId"));
            });
            services.AddHostedService<JwtRefreshTokenCache>();
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<ICommunityService, CommunityService>();
            services.AddScoped<IDesignerService, DesignerService>();
            services.AddScoped<IAdminsRepository, AdminsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoryProvidersRepository, CategoryProvidersRepository>();
            services.AddScoped<IChildCategoriesRepository, ChildCategoriesRepository>();
            services.AddScoped<IChildCategoryProvidersRepository, ChildCategoryProvidersRepository>();
            services.AddScoped<ICommunitiesRepository, CommunitiesRepository>();
            services.AddScoped<IDeliveriesRepository, DeliveriesRepository>();
            services.AddScoped<IDesignersRepository, DesignersRepository>();
            services.AddScoped<IProvidersRepository, ProvidersRepository>();
            services.AddScoped<ISmallCategoriesRepository, SmallCategoriesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICouponsRepository, CouponsRepository>();
            services.AddScoped<IShippingsRepository, ShippingsRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
