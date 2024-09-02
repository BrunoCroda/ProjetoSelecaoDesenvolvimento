using Microsoft.AspNetCore.Mvc;
using ProjetoSelecaoDesenvolvimento.Database;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Controllers
{
    [ApiController]
    [Route("api/Avaliacao")]
    public class AvaliacaoController : Controller
    {
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Avaliacao avaliacao)
        {
            AvaliacaoDb avaliacaoDb = new AvaliacaoDb();
            bool response = avaliacaoDb.Add(avaliacao);

            if (response)
            {
                return new JsonResult(new { success = true, data = "Cadastrado" });
            }
            else
            {
                return new JsonResult(new { success = false, data = "Erro" });
            }
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get(int id)
        {
            AvaliacaoDb avaliacaoDb = new AvaliacaoDb();
            Avaliacao avaliacao = avaliacaoDb.Get(id);

            if (avaliacao != null && avaliacao.id > 0)
                return new JsonResult(new { success = true, data = avaliacao });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            AvaliacaoDb avaliacaoDb = new AvaliacaoDb();
            List<Avaliacao> avaliacoes = avaliacaoDb.GetAll();

            if (avaliacoes.Count > 0)
                return new JsonResult(new { success = true, data = avaliacoes });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Avaliacao avaliacao)
        {
            AvaliacaoDb avaliacaoDb = new AvaliacaoDb();
            bool success = avaliacaoDb.Update(avaliacao);

            if (success)
                return new JsonResult(new { success = true, data = "Alterado" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            AvaliacaoDb avaliacaoDb = new AvaliacaoDb();
            bool success = avaliacaoDb.Delete(id);

            if (success)

                return new JsonResult(new { success = true, data = "Excluído" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }
    }
}
