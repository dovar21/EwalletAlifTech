using EwalletAlifTech.Modules.Accounts.Extensions;
using EwalletAlifTech.Modules.Core;
using EwalletAlifTech.Modules.Core.Filters;
using EwalletAlifTech.Modules.DigestAuthentication.Implementation;
using EwalletAlifTech.Modules.DigestAuthentication.Implementation.Extensions;
using EwalletAlifTech.Modules.DigestAuthentication.Providers;
using EwalletAlifTech.Modules.Settings.Extensions;
using EwalletAlifTech.Modules.Transactions.Extensions;
using EwalletAlifTech.Modules.Users.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EwalletAlifTech
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddSelfServices(services);
            AddMyServices(services);

            services.AddAutoMapper(typeof(Startup));
            
            services.AddScoped<IUsernameHashedSecretProvider, UsernameHashedSecretProvider>();
            
            services.AddAuthentication("Digest")
                    .AddDigestAuthentication(DigestAuthenticationConfiguration.Create("ew2022ew", "ew-realm", 60, true, 20));

            services.AddControllers().AddNewtonsoftJson();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void AddSelfServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connection, ServerVersion.AutoDetect(connection))

            );

            services.AddHttpContextAccessor();

            services.AddMvc().AddXmlSerializerFormatters();

            var sp = services.BuildServiceProvider();
            var httpContext = sp.GetService<IHttpContextAccessor>();
            var configuration = sp.GetService<IConfiguration>();

            services.AddMvc(config =>
            {
                config.Filters.Add(new ValidateModelAttribute());
                config.Filters.Add<GlobalHandlerExceptionFilter>();

            });
        }
        public void AddMyServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddUserServiceCollection();
            services.AddAccountServiceCollection();
            services.AddTransactionServiceCollection();
            services.AddSettingServiceCollection();
        }
    }
}
