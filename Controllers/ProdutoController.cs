using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiroTeste.Data;
using PrimeiroTeste.Models;
using PrimeiroTeste.Repository;

namespace PrimeiroTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepository<TbProduto> _repository;

        public ProdutoController(IRepository<TbProduto> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] TbProduto Produto)
        {
            try
            {
                _repository.Add(Produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha ao adicionar");

            }
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] TbProduto Produto)
        {
            try
            {
                _repository.Update(Produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha ao atualizar");

            }
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteById")]
        public IActionResult Delete([FromQuery]long id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha ao deletar");

            }
            return Ok();
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult Get([FromQuery]long id)
        {
            try
            {
                _repository.GetById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha ao deletar");

            }
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha ao buscar");
            }
        }
    }
}
