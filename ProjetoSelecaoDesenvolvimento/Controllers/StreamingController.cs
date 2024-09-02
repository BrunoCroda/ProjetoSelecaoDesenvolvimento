using Microsoft.AspNetCore.Mvc;
using ProjetoSelecaoDesenvolvimento.Database;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Controllers
{
    [ApiController]
    [Route("api/Streaming")]
    public class StreamingController : Controller
    {
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Streaming streaming)
        {
            StreamingDb streamingDb = new StreamingDb();
            bool response = streamingDb.Add(streaming);

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
            StreamingDb streamingDb = new StreamingDb();
            Streaming streaming = streamingDb.Get(id);

            if (streaming != null && streaming.id > 0)
                return new JsonResult(new { success = true, data = streaming });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            StreamingDb streamingDb = new StreamingDb();
            List<Streaming> streamings = streamingDb.GetAll();

            if (streamings.Count > 0)
                return new JsonResult(new { success = true, data = streamings });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Streaming streaming)
        {
            StreamingDb streamingDb = new StreamingDb();
            bool success = streamingDb.Update(streaming);

            if (success)
                return new JsonResult(new { success = true, data = "Alterado" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            StreamingDb streamingDb = new StreamingDb();
            bool success = streamingDb.Delete(id);

            if (success)

                return new JsonResult(new { success = true, data = "Excluído" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }
    }
}
