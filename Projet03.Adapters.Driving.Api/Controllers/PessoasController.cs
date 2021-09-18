using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto03.Core.Application.Interfaces;
using Projeto03.Core.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet03.Adapters.Driving.Api.Controllers
{
    [Route("api/pessoas")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaApplicationService _application;

        public PessoasController(IPessoaApplicationService application)
        {
            _application = application;
        }

        [HttpPost]
        public IActionResult Post(PessoaCreateModel model)
        {
            try
            {
                _application.Create(model);

                return Ok(new
                {
                    Message = "Pessoa cadastrado com sucesso."
                }); ;
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(PessoaUpdateModel model)
        {
            try
            {
                _application.Update(model);

                return Ok(new
                {
                    Message = "Pessoa atualizado com sucesso."
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = new PessoaDeleteModel { Id = id };
                _application.Delete(model);

                return Ok(new
                {
                    Message = "Pessoa excluído com sucesso."
                }); ;
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_application.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_application.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
