using Microsoft.AspNetCore.Mvc;
using ProjetoSelecaoDesenvolvimento.Database;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Controllers
{
    [ApiController]
    [Route("api/Genero")]
    public class GeneroController : Controller
    {
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Genero genero)
        {
            GeneroDb generoDb = new GeneroDb();
            bool response = generoDb.Add(genero);

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
            GeneroDb generoDb = new GeneroDb();
            Genero genero = generoDb.Get(id);

            if (genero != null && genero.id > 0)
                return new JsonResult(new { success = true, data = genero });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            GeneroDb generoDb = new GeneroDb();
            List<Genero> generos = generoDb.GetAll();

            if (generos.Count > 0)
                return new JsonResult(new { success = true, data = generos });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Genero genero)
        {
            GeneroDb generoDb = new GeneroDb();
            bool success = generoDb.Update(genero);

            if (success)
                return new JsonResult(new { success = true, data = "Alterado" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            GeneroDb generoDb = new GeneroDb();
            bool success = generoDb.Delete(id);

            if (success)

                return new JsonResult(new { success = true, data = "Excluído" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }
    }
}
