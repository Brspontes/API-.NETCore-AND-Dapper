﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrsPontes.Domain.StoreContext.Handlers;
using BrsPontes.Domain.StoreContext.Repositories;
using BrsPontes.Domain.StoreContext.Services;
using BrsPontes.Infra.StoreContext.DataContext;
using BrsPontes.Infra.StoreContext.Repositories;
using BrsPontes.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BrsPontes.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression();//REQUISIÇÕES COMPACTADAS, MENOR CONSUMO DE DADOS
            services.AddScoped<SQLDataContext, SQLDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailServices, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("V1", new Info { Title = "Projeto API com Dapper", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test.Web.Api");
            });
        }
    }
}
