using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ReadingLog.Common;
using ReadingLog.Common.Models.DAL;
using OperatingSystem = ReadingLog.Common.Helpers.OperatingSystem;

namespace ReadingLog.Api
{
    public class Startup
    {
        private string _connection = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (!OperatingSystem.IsWindows())
            {
                var builder = new SqlConnectionStringBuilder(
                Configuration.GetConnectionString("unixConnectionString"));
                builder.Password = Configuration["ReadingLog:MySqlPassword"];
                builder.UserID = Configuration["ReadingLog:MySqlUsername"];
                _connection = builder.ConnectionString;
            }

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

            if (OperatingSystem.IsWindows())
            {
                services.AddDbContext<ReadingLogDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("windowsConnectionString")));
            }
            else
            {
                services.AddDbContext<ReadingLogDBContext>(options =>
                {
                    var mySqlConnectionStr = Configuration.GetConnectionString("unixConnectionString");
                    services.AddEntityFrameworkMySql();
                    options.UseMySql(mySqlConnectionStr, new MySqlServerVersion(new Version(8, 0, 12)));
                });
            }

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

            if (!OperatingSystem.IsWindows())
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"DB Connection: {_connection}");
                });
            }
        }
    }
}
