using Microsoft.Extensions.DependencyInjection;
using Projeto03.Core.Application.Interfaces;
using Projeto03.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Application
{
    public static class ApplicationDependencyResolver
    {
        public static void AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPessoaApplicationService, PessoaApplicationService>();
        }
    }
}
