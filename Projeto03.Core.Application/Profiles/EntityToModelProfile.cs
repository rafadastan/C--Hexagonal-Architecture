using AutoMapper;
using Projeto03.Core.Application.Models;
using Projeto03.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Application.Profiles
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<Pessoa, PessoaGetModel>();
        }
    }
}
