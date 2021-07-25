using Microsoft.AspNetCore.Mvc;
using projEntrevista.Models;
using projEntrevista.Repository;
using System;

namespace projEntrevista.Controllers
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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_pessoaRepository.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_pessoaRepository.GetById(id));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert(PessoaModels pessoa)
        {
            try
            {
                _pessoaRepository.Insert(pessoa);
                return StatusCode(201);
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PessoaModels pessoa)
        {
            try
            {
                _pessoaRepository.Update(id, pessoa);
                return Ok();
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _pessoaRepository.Delete(id);
                return Ok();
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
