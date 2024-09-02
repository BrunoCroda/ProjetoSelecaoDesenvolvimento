using Microsoft.AspNetCore.Mvc;
using ProjetoSelecaoDesenvolvimento.Database;
using ProjetoSelecaoDesenvolvimento.Models;

namespace ProjetoSelecaoDesenvolvimento.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Usuario usuario)
        {
            UsuarioDb usuarioDb = new UsuarioDb();
            bool response = usuarioDb.Add(usuario);

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
            UsuarioDb usuarioDb = new UsuarioDb();
            Usuario usuario = usuarioDb.Get(id);

            if (usuario != null && usuario.id > 0)
                return new JsonResult(new { success = true, data = usuario });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpGet]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            UsuarioDb usuarioDb = new UsuarioDb();
            List<Usuario> usuarios = usuarioDb.GetAll();

            if (usuarios.Count > 0)
                return new JsonResult(new { success = true, data = usuarios });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Usuario usuario)
        {
            UsuarioDb usuarioDb = new UsuarioDb();
            bool success = usuarioDb.Update(usuario);

            if (success)
                return new JsonResult(new { success = true, data = "Alterado" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            UsuarioDb usuarioDb = new UsuarioDb();
            bool success = usuarioDb.Delete(id);

            if (success)

                return new JsonResult(new { success = true, data = "Excluído" });
            else
                return new JsonResult(new { success = false, data = "Erro" });
        }
    }
}
