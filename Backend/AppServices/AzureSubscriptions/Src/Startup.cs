using CloudYourself.Backend.AppServices.AzureSubscriptions.Infrastructure;
using CloudYourself.Backend.AppServices.AzureSubscriptions.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace CloudYourself.Backend.AppServices.AzureSubscriptions
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
            // Add database services
            string dbConnectionString = Configuration.GetConnectionString("DbConnection");
            services.AddDbContext<AzureSubscriptionsDbContext>(options => options.UseSqlServer(dbConnectionString));

            // Add system services
            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CloudYourself.Backend.AppServices.AzureSubscriptions", Version = "v1" });
            });

            // Add app services
            services.AddTransient<AzureSubscriptionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AzureSubscriptionsDbContext dbContext)
        {
            // Migrate database to latest version
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CloudYourself.Backend.AppServices.AzureSubscriptions v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
