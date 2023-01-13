using CompanyRegistration.Data;
using CompanyRegistration.Manager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CompanyRegistration
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
           
            services.AddTransient<IRegister, Register>();
            services.AddTransient<ICdetail, Cdetail> ();
            services.AddAuthentication();
            services.CustomAuthentication(this.Configuration);

            services.SwaggerGenConfig(this.Configuration);
            services.ApiVersionConfig();

            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<CompanyDbContext>(options => options.UseSqlServer(connectionString));

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompanyRegistration", Version = "v1" });
            //});

            //services.AddCors(option =>
            //{
            //    option.AddDefaultPolicy(builder =>
            //    {
            //        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //    });
            //});
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , IApiVersionDescriptionProvider provider )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseSwagger();
               // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyRegistration v1"));
                app.SwaggerUIConfig(provider);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            
            app.UseCors( x => x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
