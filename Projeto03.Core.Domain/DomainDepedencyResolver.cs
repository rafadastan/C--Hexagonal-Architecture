using Microsoft.Extensions.DependencyInjection;
using Projeto03.Core.Domain.Interfaces.Services;
using Projeto03.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Domain
{
    public static class DomainDependencyResolver
    {
        public static void AddDomainConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IPessoaDomainService, PessoaDomainService>();
        }
    }
}
