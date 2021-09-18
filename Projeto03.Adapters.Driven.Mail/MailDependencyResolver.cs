using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto03.Adapters.Driven.Mail.Messages;
using Projeto03.Adapters.Driven.Mail.Settings;
using Projeto03.Core.Domain.Interfaces.Adapters.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Adapters.Driven.Mail
{
    public static class MailDependencyResolver
    {
        public static void AddMailConfiguration(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var mailSettings = configuration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailSettings);


            //configurar a injeção de dependencia para fazer envio de emails
            services.AddTransient<IMailMessage>(map => new MailMessage(mailSettings.Get<MailSettings>()));
        }
    }
}
