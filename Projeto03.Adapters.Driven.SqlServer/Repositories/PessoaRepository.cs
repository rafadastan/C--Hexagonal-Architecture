using Projeto03.Adapters.Driven.SqlServer.Contexts;
using Projeto03.Core.Domain.Entities;
using Projeto03.Core.Domain.Interfaces.Adapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Adapters.Driven.SqlServer.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa, Guid>, IPessoaRepository
    {
        private readonly SqlServerContext _context;

        public PessoaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
    }
}
