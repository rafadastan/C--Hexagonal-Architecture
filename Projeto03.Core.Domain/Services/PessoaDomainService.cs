using Projeto03.Core.Domain.Entities;
using Projeto03.Core.Domain.Interfaces.Adapters.Repositories;
using Projeto03.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Domain.Services
{
    public class PessoaDomainService : BaseDomainService<Pessoa, Guid>, IPessoaDomainService
    {
        private readonly IPessoaRepository _repository;

        public PessoaDomainService(IPessoaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
