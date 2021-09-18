using Projeto03.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Domain.Interfaces.Adapters.Repositories
{
    public interface IPessoaRepository : IBaseRepository<Pessoa, Guid>
    {

    }
}
