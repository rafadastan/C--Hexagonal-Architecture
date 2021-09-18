using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto03.Adapters.Driven.SqlServer.Contexts;
using Projeto03.Adapters.Driven.SqlServer.Repositories;
using Projeto03.Core.Domain.Interfaces.Adapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Adapters.Driven.SqlServer
{
    public static class SqlServerDepedencyResolver
    {
        public static void AddSqlServerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //**Instalar: Microsoft.Extensions.Options.ConfigurationExtensions
            //**Instalar: Microsoft.Extensions.DependencyInjection
            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("Projeto03")));

            services.AddTransient<IPessoaRepository, PessoaRepository>();
        }
    }
}
