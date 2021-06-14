using APIDapper.Model;
using APIDapper.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APIDapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        
        [HttpGet()]
        public IActionResult GetPessoa()
        {
            try
            {
                return Ok(_pessoaRepository.GetPessoa());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("GetById/{pessoaid}")]
        public IActionResult GetPessoasById(int pessoaid)
        {
            try
            {
               return Ok(_pessoaRepository.GetPessoasById(pessoaid));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }


        [HttpPost]
        public IActionResult SetPessoa(PessoaModel pessoa)
        {
            try
            {
                int p = _pessoaRepository.GetPessoaId();
                pessoa.pessoaId = ++p;

                bool result = _pessoaRepository.SetPessoa(pessoa);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            
        }

    }
}
