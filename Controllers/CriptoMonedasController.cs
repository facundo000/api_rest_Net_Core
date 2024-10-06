using Microsoft.AspNetCore.Mvc;
using ParcialWebApi.DTOs;
using ParcialWebApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcialWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriptoMonedasController : ControllerBase
    {
        private readonly ICriptoRepository _repository;

        public CriptoMonedasController(ICriptoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CriptoMonedasController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno!! {ex.Message}");
            }
        }
        //categorias
        [HttpGet("Categorias")]
        public IActionResult GetCategorias()
        {
            try
            {
                return Ok(_repository.GetAllCategorias());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno!! {ex.Message}");
            }
        }

        // PUT api/<CriptoMonedasController>/5
        [HttpPut("{simbolo}")]
        public IActionResult Put(string simbolo, [FromBody] CriptomonedaDTO cripto)
        {
            try
            {
                if (_repository.Update(simbolo, cripto))
                {
                    return Ok("Actualizado correctamente! :)");
                }
                else
                {
                    return BadRequest("La criptomoneda no se encuentra o algun campo no es válido");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno!! {ex.Message}");
            }
        }

        // DELETE api/<CriptoMonedasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_repository.Delete(id))
                {
                    return Ok("'Eliminado' correctamente :)");
                }
                else
                {
                    return BadRequest("La criptomoneda no se encuentra o ya está eliminada");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno!! {ex.Message}");
            }
        }
    }
}
