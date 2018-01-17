using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WebMarkupMin.AspNetCore1;

namespace ApplicationManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private ILogger _logger;
        private IHostingEnvironment env;

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            this.env = env;
            _logger = loggerFactory.CreateLogger<Startup>();
            //Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Configuration Service
            services.AddSingleton<IConfiguration>(Configuration);

            // Add framework services.
            services.AddMvc();

            //Configure Connection and EntityFramework Service.
#if DEBUG
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DevelopConnection"),
                    providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );
#else
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
#endif

            //HTML minifire service
            //With This - using WebMarkupMin.AspNetCore1;
            services.AddWebMarkupMin(
                options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = false;
                    options.AllowCompressionInDevelopmentEnvironment = false;
                })
                .AddHtmlMinification(
                    options =>
                    {
                        options.MinificationSettings.RemoveRedundantAttributes = true;
                        options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                        options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;

                        options.MinificationSettings.RemoveEmptyAttributes = true;
                        options.MinificationSettings.RemoveHtmlComments = true;
                        options.MinificationSettings.RemoveOptionalEndTags = true;
                    })
                .AddHttpCompression();

            // Add Configuration Manager services.
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext applicationDbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //Seed The Database
            try
            {
                applicationDbContext.Seed(app);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            app.UseStaticFiles();

            //HTML Minifire
            //With This - using WebMarkupMin.AspNetCore1;
            app.UseWebMarkupMin();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // NOTE: this must go at the end of Configure
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                try
                {
#if DEBUG
                    dbContext.Database.EnsureDeleted();
#endif
                    dbContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }
        }
    }
}
