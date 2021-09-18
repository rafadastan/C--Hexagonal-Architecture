using AutoMapper;
using Projeto03.Core.Application.Interfaces;
using Projeto03.Core.Application.Models;
using Projeto03.Core.Domain.Entities;
using Projeto03.Core.Domain.Interfaces.Adapters.Messages;
using Projeto03.Core.Domain.Interfaces.Services;
using Projeto03.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Application.Services
{
    public class PessoaApplicationService : IPessoaApplicationService
    {
        private readonly IPessoaDomainService _domain;
        private readonly IMailMessage _mail;
        private readonly IMapper _mapper;

        public PessoaApplicationService(IPessoaDomainService domain, IMailMessage mail, IMapper mapper)
        {
            _domain = domain;
            _mail = mail;
            _mapper = mapper;
        }

        public void Create(PessoaCreateModel model)
        {
            var pessoa = _mapper.Map<Pessoa>(model);

            if (pessoa.IsValid)
            {
                _domain.Create(pessoa);

                var message = new MessageModel
                {
                    To = pessoa.Email,
                    Subject = $"Cadastro realizado com sucesso ({pessoa.PrimeiroNome} {pessoa.Sobrenome})",
                    Body = $"Parabens {pessoa.PrimeiroNome} <br/><br/>Seu cadastro foi realizado com sucesso!",
                    IsHtml = true
                };

                _mail.SendMessage(message);
            }
        }

        public void Delete(PessoaDeleteModel model)
        {
            var pessoa = _domain.GetById(model.Id.Value);

            if (pessoa != null && pessoa.IsValid)
            {
                _domain.Delete(pessoa);
            }
            else
            {
                throw new Exception("Pessoa não encontrada");
            }
        }

        public List<PessoaGetModel> GetAll()
        {
            return _mapper.Map<List<PessoaGetModel>>(_domain.GetAll());
        }

        public PessoaGetModel GetById(Guid key)
        {
            return _mapper.Map<PessoaGetModel>(_domain.GetById(key));
        }

        public void Update(PessoaUpdateModel model)
        {
            var pessoa = _mapper.Map<Pessoa>(model);

            if (pessoa.IsValid)
            {
                _domain.Update(pessoa);
            }
        }

        public void Dispose()
        {
            _domain.Dispose();
        }
    }
}
