using ProjetoReceitas.DAL;
using ProjetoReceitas.Models;
using ProjetoReceitas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoReceitas.Controllers
{
    [RoutePrefix("api/Receita")]
    public class ReceitasAPIController : ApiController
    {

        [Route("Receitas")]
        public List<Receita> GetReceitas()
        {
            return ReceitaDAO.RetornarReceitas();
        }

        [Route("Receitas/{id}")]
        public dynamic GetBuscarReceitaPorId(int id)
        {
            Receita receita = ReceitaDAO.BuscarReceitaPorId(id);
            if(receita != null)
            {
                dynamic objeto = new
                {
                    Titulo = receita.Titulo,
                    TipoRefeicao = receita.TipoRefeicao,
                    NivelDificuldade = receita.NivelDificuldade,
                    TempoPreparo = receita.TempoPreparo,
                    ModoDePreparo = receita.ModoDePreparo,
                    Ingredientes = receita.Ingredientes
                };
                return objeto;
            }
            return NotFound();
        }

        [Route("Cadastrar")]
        public IHttpActionResult PostCadastrarReceita(Receita receita)
        {
            if(!ModelState.IsValid || receita == null)
            {
                return BadRequest(ModelState);
            }
            
           
            if (ReceitaDAO.CadastrarReceita(receita))
            {
                return Created("", receita);
            }
            return NotFound();
        }

        [Route("Receita/{id}")]
        public IHttpActionResult DeleteReceita(int id)
        {
            Receita receita = ReceitaDAO.BuscarReceitaPorId(id);
            if (receita == null)
            {
                return NotFound();
            }

            ReceitaDAO.RemoverReceita(receita);

            return Ok(receita);
        }

        [Route("Receita/{id}")]
        public IHttpActionResult PutAlterarReceita(int id, Receita receita)
        {
            Receita r = ReceitaDAO.BuscarReceitaPorId(id);
            
            if (r == null)
            {
                return BadRequest();
            }
            r.Titulo = receita.Titulo;
            r.TipoRefeicao = receita.TipoRefeicao;
            r.NivelDificuldade = receita.NivelDificuldade;
            r.ModoDePreparo = receita.ModoDePreparo;
            r.TempoPreparo = receita.TempoPreparo;
            r.Ingredientes = receita.Ingredientes;
            r.Usuario = receita.Usuario;
            ReceitaDAO.AlterarReceita(r);
            return Ok(r);
        }
    }
}
