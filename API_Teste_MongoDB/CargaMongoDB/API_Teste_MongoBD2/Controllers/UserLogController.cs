using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Teste_MongoBD2.Data;
using API_Teste_MongoBD2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Teste_MongoBD2.Controllers
{
    [Route("api/[controller]")]
    public class UserLogController : Controller
    {

        private UserLogContext _contextUserLog;

        public UserLogController(UserLogContext context)
        {
            _contextUserLog = context;
        }

        //Listagem de todos os elementos da coleção
        [HttpGet]
        public List<UserLog> Get()
        {
            return _contextUserLog.Get();
        }
        //Lista um elemento da coleção userLog através do código
        [HttpGet("{id}")]
        public ActionResult<UserLog> GetUserLog(string id)
        {
            return _contextUserLog.Get(id);
        }

        //Salvar um elemento na coleção grade
        [HttpPost("save/")]
        public ActionResult Create([FromBody] UserLog userLog)
        {
            _contextUserLog.Create(userLog);
            return CreatedAtRoute("GetUserLog", new { id = userLog.id.ToString() }, userLog);
        }

        //Atualiza um elemento da coleção grade
        [HttpPut("update/{id}/")]
        public IActionResult Update(string id, [FromBody] UserLog userLogIn)
        {
            var userLog = _contextUserLog.Get(id);
            if (userLog == null)
            {
                return NotFound();
            }
            userLogIn._id = userLog._id;
            _contextUserLog.Update(id, userLogIn);
            return NoContent();

        }


        //Remove um elemento da coleção grade através do id
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(string id)
        {
            var userLog = _contextUserLog.Get(id);
            if (userLog == null)
            {
                return NotFound();
            }
            _contextUserLog.Remove(userLog.id);

            return NoContent();
        }


       

                       

    }
}