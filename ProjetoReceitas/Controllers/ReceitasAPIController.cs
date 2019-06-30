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
        public List<Receita> GETReceitas()
        {
            return ReceitaDAO.RetornarReceitas();
        }

        [Route("Receitas/{id}")]
        public dynamic GETBuscarReceitaPorId(int id)
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
                    ModoDePreparo = receita.ModoDePreparo
                };
                return objeto;
            }
            return NotFound();
        }

        [Route("CadastrarReceita")]
        public IHttpActionResult POSTCadastrarReceita(Receita receita)
        {
            if(ModelState.IsValid || receita == null)
            {
                return BadRequest(ModelState);
            }
            receita.TipoRefeicao = TipoRefeicaoDAO.BuscarTipoRefeicaoPorId(receita.TipoRefeicao.TipoRefeicaoId);
            receita.NivelDificuldade = NivelDificuldadeDAO.BuscarNivelDificuldadePorId(receita.NivelDificuldade.DificuldadeId);
           
            if (ReceitaDAO.CadastrarReceita(receita))
            {
                return Created("", receita);
            }
            return Conflict();
        }
    }
}
