using Projeto03.Core.Domain.Entities;
using Projeto03.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Domain.Interfaces.Adapters.Messages
{
    public interface IMailMessage
    {
        void SendMessage(MessageModel model);
    }
}
