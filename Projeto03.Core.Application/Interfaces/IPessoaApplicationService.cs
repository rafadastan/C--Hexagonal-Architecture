using Projeto03.Core.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Application.Interfaces
{
    public interface IPessoaApplicationService : IDisposable
    {
        void Create(PessoaCreateModel model);
        void Update(PessoaUpdateModel model);
        void Delete(PessoaDeleteModel model);

        List<PessoaGetModel> GetAll();
        PessoaGetModel GetById(Guid key);
    }
}
