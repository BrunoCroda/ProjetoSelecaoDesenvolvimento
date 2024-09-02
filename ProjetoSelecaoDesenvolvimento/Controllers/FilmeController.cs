using Microsoft.AspNetCore.Mvc;
using ProjetoSelecaoDesenvolvimento.Database;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Controllers
{
    [ApiController]
    [Route("api/Filme")]
    public class FilmeController : Controller
    {
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Filme filme)
        {
            FilmeDb filmeDb = new FilmeDb();
            bool response = filmeDb.Add(filme);

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
            FilmeDb filmeDb = new FilmeDb();
            Filme filme = filmeDb.Get(id);

            if (filme != null && filme.id > 0)
                return new JsonResult(new { success = true, data = filme });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            FilmeDb filmeDb = new FilmeDb();
            List<Filme> produtos = filmeDb.GetAll();

            if (produtos.Count > 0)
                return new JsonResult(new { success = true, data = produtos });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Filme filme)
        {
            FilmeDb productDb = new FilmeDb();
            bool success = productDb.Update(filme);

            if (success)
                return new JsonResult(new { success = true, data = "Alterado" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            FilmeDb productDb = new FilmeDb();
            bool success = productDb.Delete(id);

            if (success)

                return new JsonResult(new { success = true, data = "Excluído" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }
    }
}
