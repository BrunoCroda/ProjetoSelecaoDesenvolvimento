using Microsoft.AspNetCore.Mvc;
using ProjetoSelecaoDesenvolvimento.Database;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Controllers
{
    [ApiController]
    [Route("api/FilmeStreaming")]
    public class FilmeStreamingController : Controller
    {
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(FilmeStreaming filmeStreaming)
        {
            FilmeStreamingDb filmeStreamingDb = new FilmeStreamingDb();
            bool response = filmeStreamingDb.Add(filmeStreaming);

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
            FilmeStreamingDb filmeStreamingDb = new FilmeStreamingDb();
            FilmeStreaming filmeStreaming = filmeStreamingDb.Get(id);

            if (filmeStreaming != null && filmeStreaming.id > 0)
                return new JsonResult(new { success = true, data = filmeStreaming });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            FilmeStreamingDb filmeStreamingDb = new FilmeStreamingDb();
            List<FilmeStreaming> filmeStreamings = filmeStreamingDb.GetAll();

            if (filmeStreamings.Count > 0)
                return new JsonResult(new { success = true, data = filmeStreamings });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update(FilmeStreaming filmeStreaming)
        {
            FilmeStreamingDb filmeStreamingDb = new FilmeStreamingDb();
            bool success = filmeStreamingDb.Update(filmeStreaming);

            if (success)
                return new JsonResult(new { success = true, data = "Alterado" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            FilmeStreamingDb filmeStreamingDb = new FilmeStreamingDb();
            bool success = filmeStreamingDb.Delete(id);

            if (success)

                return new JsonResult(new { success = true, data = "Excluído" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }
    }
}
