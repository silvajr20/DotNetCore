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
    [ApiController]
    public class UserProgressController : Controller
    {
                       
        private UserProgressContext _contextUserProgress;

        public UserProgressController(UserProgressContext context)
        {
            _contextUserProgress = context;
        }

        //Listagem de todos os elementos da coleção
        [HttpGet]
        public List<UserProgress> Get()
        {
            return _contextUserProgress.Get();
        }
        //Lista um elemento da coleção userLog através do código
        [HttpGet("{id}")]
        public ActionResult<UserProgress> GetUserProgress(string id)
        {
            return _contextUserProgress.Get(id);
        }

        //Salvar um elemento na coleção grade
        [HttpPost("save/")]
        public ActionResult Create([FromBody] UserProgress userprogress)
        {
            _contextUserProgress.Create(userprogress);
            return CreatedAtRoute("GetUserProgress", new { id = userprogress.id.ToString() }, userprogress);
        }

        //Atualiza um elemento da coleção grade
        [HttpPut("update/{id}/")]
        public IActionResult Update(string id, [FromBody] UserProgress userprogressIn)
        {
            var userprogress = _contextUserProgress.Get(id);
            if (userprogress == null)
            {
                return NotFound();
            }
            userprogressIn._id = userprogress._id;
            _contextUserProgress.Update(id, userprogressIn);
            return NoContent();

        }


        //Remove um elemento da coleção grade através do id
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(string id)
        {
            var userprogress = _contextUserProgress.Get(id);
            if (userprogress == null)
            {
                return NotFound();
            }
            _contextUserProgress.Remove(userprogress.id);

            return NoContent();
        }


    }
}
