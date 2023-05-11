using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCP.Pharma.DL.Repository;
using HCP.Pharma.IF;
using HCP.Pharma.WebAPI.Utility;
using DL_eSyaPharma = HCP.Pharma.DL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using HCP.Pharma.DL.Entities;

namespace HCP.Pharma.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(HttpAuthAttribute));
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //});

            services.AddScoped<IDrugManufacturerRepository, DrugManufacturerRepository>();
            services.AddScoped<IDrugCategoryRepository, DrugCategoryRepository>();
            services.AddScoped<IDrugFormulationRepository, DrugFormulationRepository>();
            services.AddScoped<ICommonDataRepository, CommonDataRepository>();
            services.AddScoped<IDrugBrandRepository, DrugBrandRepository>();
            services.AddScoped<IGenericRepository, GenericRepository>();

            DL_eSyaPharma.eSyaEnterprise._connString = Configuration.GetConnectionString("dbConn_eSyaEnterprise");

            services.AddDbContext<eSyaEnterprise>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("prod:dbConn_eSyaEnterprise")));
        }
        



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes
                    .MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}")
                    .MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
            });

            app.UseMvc();
        }
    }
}
