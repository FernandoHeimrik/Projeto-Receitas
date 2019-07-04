using ProjetoReceitas.DAL;
using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoReceitas.Controllers
{
    [RoutePrefix("api/Ingrediente")]
    public class IngredientesAPIController : ApiController
    {

        [Route("Ingredientes")]
        public List<Ingrediente> GetIngredientes()
        {
            return IngredienteDAO.RetornarIngredientes();
        }


        [Route("Ingrediente/{id}")]
        public dynamic GetBuscarIngredientePorId(int id)
        {
            Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(id);
            if (ingrediente != null)
            {
                dynamic objeto = new
                {
                    Nome = ingrediente.Nome

                };
                return objeto;
            }
            return NotFound();
        }

        [Route("Cadastrar")]
        public IHttpActionResult PostIngrediente(Ingrediente ingrediente)
        {
            if (!ModelState.IsValid || ingrediente == null)
            {
                return BadRequest(ModelState);
            }

            if (IngredienteDAO.CadastrarIngrediente(ingrediente))
            {
                return Created("", ingrediente);
            }
            return Conflict();
        }


        [Route("Ingrediente/{id}")]
        public IHttpActionResult DeleteIngrediente(int id)
        {
            Ingrediente ingrediente = IngredienteDAO.BuscarIngredientePorId(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            IngredienteDAO.RemoverIngrediente(ingrediente);

            return Ok(ingrediente);
        }
    }
}
