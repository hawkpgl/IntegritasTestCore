using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using PL.Integritas.Application.Interfaces;
using PL.Integritas.Application;
using PL.Integritas.Infra.Data.Repository;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Domain.Interfaces.Services;
using PL.Integritas.Domain.Services;
using Microsoft.EntityFrameworkCore;
using PL.Integritas.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using PL.Integritas.Infra.Data.Interfaces;
using PL.Integritas.Infra.Data.UoW;

namespace PL.Integritas.Services.RESTCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowEverything",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc()
                .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowEverything"));
            });

            services.AddDbContext<IntegritasContext>(options =>
                options.UseSqlServer(@"Server=DESKTOP-SLOU7DL\LOCALDB;Database=IntegritasDB;Trusted_Connection=True;"), ServiceLifetime.Scoped);

            //App IoC
            services.AddSingleton<IProductAppService, ProductAppService>();
            services.AddSingleton<IPurchaseAppService, PurchaseAppService>();
            services.AddSingleton<IShoppingCartAppService, ShoppingCartAppService>();

            //Data IoC
            services.AddSingleton<IUnityOfWork, UnityOfWork>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IPurchaseRepository, PurchaseRepository>();
            services.AddSingleton<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddSingleton<IShoppingCartItemRepository, ShoppingCartItemRepository>();

            //Domain IoC
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IPurchaseService, PurchaseService>();
            services.AddSingleton<IShoppingCartService, ShoppingCartService>();
            services.AddSingleton<IShoppingCartItemService, ShoppingCartItemService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("AllowEverything");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
