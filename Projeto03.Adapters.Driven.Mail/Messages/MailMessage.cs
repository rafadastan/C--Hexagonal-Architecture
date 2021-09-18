using Projeto03.Adapters.Driven.Mail.Settings;
using Projeto03.Core.Domain.Interfaces.Adapters.Messages;
using Projeto03.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Adapters.Driven.Mail.Messages
{
    public class MailMessage : IMailMessage
    {
        private readonly MailSettings _settings;

        public MailMessage(MailSettings settings)
        {
            _settings = settings;
        }

        public void SendMessage(MessageModel model)
        {
            var mail = new System.Net.Mail.MailMessage(_settings.Email, model.To);

            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = model.IsHtml;

            var smtp = new SmtpClient(_settings.Smtp, _settings.Port);
            smtp.Credentials = new NetworkCredential(_settings.Email, _settings.Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
