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
    public class UserDetailController : Controller
    {

        private UserDetailContext _contextUserDetail;

        public UserDetailController(UserDetailContext context)
        {
            _contextUserDetail = context;
        }

        //Listagem de todos os elementos da coleção
        [HttpGet]
        public List<UserDetail> Get()
        {
            return _contextUserDetail.Get();
        }
        //Lista um elemento da coleção userdetail através do código
        [HttpGet("{id}")]
        public ActionResult<UserDetail> GetUserDetail(string id)
        {
            return _contextUserDetail.Get(id);
        }

        //Salvar um elemento na coleção userdetail
        [HttpPost("save")]
        public ActionResult Create([FromBody] UserDetail userdetail)
        {

            _contextUserDetail.Create(userdetail);
            return CreatedAtRoute("GetUserDetail", new { id = userdetail.id.ToString() }, userdetail);
        }

        //Atualiza um elemento da coleção userdetail
        [HttpPut("update/{id}/")]
        public IActionResult Update(string id, [FromBody] UserDetail userdetailIn)
        {
            var userdetail = _contextUserDetail.Get(id);
            if (userdetail == null)
            {
                return NotFound();
            }
            userdetailIn._id = userdetail._id;
            _contextUserDetail.Update(id, userdetailIn);
            return NoContent();

        }


        //Remove um elemento da coleção grade através do id
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(string id)
        {
            var userdetail = _contextUserDetail.Get(id);
            if (userdetail == null)
            {
                return NotFound();
            }
            _contextUserDetail.Remove(userdetail.id);

            return NoContent();
        }


    }
}