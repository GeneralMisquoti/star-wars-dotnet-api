using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NodaTime;
using NodaTime.Serialization.SystemTextJson;
using Npgsql;
using PL_452490_P2.Data;

namespace PL_452490_P2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            NpgsqlConnection.GlobalTypeMapper.UseNodaTime();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddRouting(options => options.LowercaseUrls = true);
            services.AddDbContext<MyContext>();
            services.AddRazorPages();
            services.AddControllersWithViews()
                .AddXmlSerializerFormatters()
                .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                        options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
                        options.JsonSerializerOptions.IgnoreNullValues = true;

                        // options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    }
                );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "PL_452490_P2", Version = "v1"});
                c.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PL_452490_P2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
            // app.UseMvc();
            // app.UseWelcomePage();
        }
    }
}