using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Domain.Entities
{
    public class Pessoa
    {
        public Guid? Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        #region Validações

        public bool IsValid
        {
            get
            {
                Validate();
                return true;
            }
        }

        private void Validate()
        {
            if (Id == null || Id == Guid.Empty)
                throw new Exception("Por favor informe o ID");

            if (string.IsNullOrWhiteSpace(PrimeiroNome))
                throw new Exception("Informe o Primeiro Nome");

            if (string.IsNullOrWhiteSpace(Sobrenome))
                throw new Exception("Informe o Sobrenome");
        }

        #endregion
    }
}
