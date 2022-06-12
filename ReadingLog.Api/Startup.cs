using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ReadingLog.Common;
using ReadingLog.Common.Helpers;
using ReadingLog.Common.Models.DAL;

namespace ReadingLog.Api
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
            services.AddControllers();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Heyy", Version = "v1" });

                var modelDocPath = string.Empty;
                if (OperatingSystem.IsMacOS())
                {
                    modelDocPath = "../../../../ReadingLog.Common/bin/Debug/netcoreapp3.1/ModelDoc.xml";
                }
                else
                {
                    modelDocPath = "..\\..\\..\\..\\ReadingLog.Common\\bin\\Debug\\netcoreapp3.1\\ModelDoc.xml  ";
                }

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "ApiDoc.xml");
                var filePath2 = Path.Combine(System.AppContext.BaseDirectory, modelDocPath);
                c.IncludeXmlComments(filePath);
                c.IncludeXmlComments(filePath2);
            });

            services.AddDbContext<ReadingLogDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ReadingLog")));

            services.AddTransient<IAuthorRepository, AuthorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Hello there!");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
