using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet03.Adapters.Driving.Api
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
            #region Injeção de dependencia

            ApiDependencyResolver.AddApiConfiguration(services);

            Projeto03.Adapters.Driven.Mail.MailDependencyResolver.AddMailConfiguration(services, Configuration);
            Projeto03.Adapters.Driven.SqlServer.SqlServerDepedencyResolver.AddSqlServerConfiguration(services, Configuration);

            Projeto03.Core.Domain.DomainDependencyResolver.AddDomainConfiguration(services);
            Projeto03.Core.Application.ApplicationDependencyResolver.AddApplicationConfiguration(services);

            #endregion

            services.AddControllers();
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

            #region Injeção de dependência

            ApiDependencyResolver.UseApiConfiguration(app);

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
