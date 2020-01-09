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
    public class UserMatchDetailsController : Controller
    {

        private UserMatchDetailsContext _contextUserMatchDetails;

        public UserMatchDetailsController(UserMatchDetailsContext context)
        {
            _contextUserMatchDetails = context;
        }

        //Listagem de todos os elementos da coleção
        [HttpGet]
        public List<UserMatchDetails> Get()
        {
            return _contextUserMatchDetails.Get();
        }
        //Lista um elemento da coleção usermatchdetails através do código
        [HttpGet("{id}")]
        public ActionResult<UserMatchDetails> GetUserMatchDetail(string id)
        {
            return _contextUserMatchDetails.Get(id);
        }

        //Salvar um elemento na coleção usermatchdetails
        [HttpPost("save")]
        public ActionResult Create([FromBody] UserMatchDetails usermatchdetails)
        {

            _contextUserMatchDetails.Create(usermatchdetails);
            return CreatedAtRoute("GetUserMatchDetail", new { id = usermatchdetails.id.ToString() }, usermatchdetails);
        }

        //Atualiza um elemento da coleção usermatchdetails
        [HttpPut("update/{id}/")]
        public IActionResult Update(string id, [FromBody] UserMatchDetails usermatchDetailsIn)
        {
            var usermatchdetails = _contextUserMatchDetails.Get(id);
            if (usermatchdetails == null)
            {
                return NotFound();
            }
            usermatchDetailsIn._id = usermatchdetails._id;
            _contextUserMatchDetails.Update(id, usermatchDetailsIn);
            return NoContent();

        }


        //Remove um elemento da coleção usermatchdetails através do id
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(string id)
        {
            var usermatchdetails = _contextUserMatchDetails.Get(id);
            if (usermatchdetails == null)
            {
                return NotFound();
            }
            _contextUserMatchDetails.Remove(usermatchdetails.id);

            return NoContent();
        }



    }
}