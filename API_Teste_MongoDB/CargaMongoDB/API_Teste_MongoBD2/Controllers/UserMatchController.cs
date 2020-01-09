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
    public class UserMatchController : Controller
    {

        private UserMatchContext _contextUserMatch;

        public UserMatchController(UserMatchContext context)
        {
            _contextUserMatch = context;
        }

        //Listagem de todos os elementos da coleção
        [HttpGet]
        public List<UserMatch> Get()
        {
            return _contextUserMatch.Get();
        }
        //Lista um elemento da coleção usermatch através do código
        [HttpGet("{id}")]
        public ActionResult<UserMatch> GetUserDetail(string id)
        {
            return _contextUserMatch.Get(id);
        }

        //Salvar um elemento na coleção usermatch
        [HttpPost("save")]
        public ActionResult Create([FromBody] UserMatch usermatch)
        {

            _contextUserMatch.Create(usermatch);
            return CreatedAtRoute("GetUserDetail", new { id = usermatch.id.ToString() }, usermatch);
        }

        //Atualiza um elemento da coleção usermatch
        [HttpPut("update/{id}/")]
        public IActionResult Update(string id, [FromBody] UserMatch usermatchIn)
        {
            var usermatch = _contextUserMatch.Get(id);
            if (usermatch == null)
            {
                return NotFound();
            }
            usermatchIn._id = usermatch._id;
            _contextUserMatch.Update(id, usermatchIn);
            return NoContent();

        }


        //Remove um elemento da coleção grade através do id
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(string id)
        {
            var usermatch = _contextUserMatch.Get(id);
            if (usermatch == null)
            {
                return NotFound();
            }
            _contextUserMatch.Remove(usermatch.id);

            return NoContent();
        }

    }
}