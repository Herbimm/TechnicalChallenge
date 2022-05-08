using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TechnicalChallenge.Domain.Filters;
using TechnicalChallenge.Infra.Ioc;


namespace TechnicalChallenge.Api
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
            

            services.AddInfrastructure(Configuration);
            services.AddControllers();
            services.AddControllers(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation();
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                var desc = $"SWS API <br />{new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime}";

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                    Title = "TechnicalChallenge",
                    Description = desc
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                           "JWT Authorization header using the Bearer scheme." +
                           " \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "identity",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                 });
            });
            #endregion

          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
