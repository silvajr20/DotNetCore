using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Teste_MongoDB.Data;
using API_Teste_MongoDB.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_Teste_MongoDB.Controllers
{
        // Rota do navegador:       https://localhost:5001/api/Grade/grades/2
    [Route("api/[controller]")]
    public class GradeController : Controller
    {
        private GradeContext _contextGrade;

        public GradeController(GradeContext context)
        {
            _contextGrade = context;
        }

        //Listagem de todos os elementos da coleção
        [HttpGet]       
        public List<Grade> Get()
        {
            return _contextGrade.Get();
        }
        //Lista um elemento da coleção grade através do código
        [HttpGet("grades/{id}")]
        public ActionResult<Grade> GetGrade(string id)
        {
            return _contextGrade.Get(id);
        }
             
        //Salvar um elemento na coleção grade
        [HttpPost("save/")]
        public ActionResult Create([FromBody] Grade grade)
        {

            _contextGrade.Create(grade);
            return CreatedAtRoute("GetGrade", new { id = grade.id.ToString() }, grade);
        }

        //Atualiza um elemento da coleção grade
        [HttpPut("update/{id}/")]
        public IActionResult Update(string id, [FromBody] Grade gradeIn)
        {
            var grade = _contextGrade.Get(id);
            if (grade == null)
            {
                return NotFound();
            }
            gradeIn._id = grade._id;
            _contextGrade.Update(id, gradeIn);
            return NoContent();

        }


        //Remove um elemento da coleção grade através do id
        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(string id)
        {
            var grade = _contextGrade.Get(id);
            if (grade == null)
            {
                return NotFound();
            }
            _contextGrade.Remove(grade.id);

            return NoContent();
        }


        /*
        //Listagem pelo código
        [HttpGet("grades/{id}")]
        public ActionResult<Grade> GetGrade(string id)
        {
            Grade grade = null;
            //if (id.StartsWith("GRAD"))
            grade = _context.ObterItem<Grade>(id);

            if (grade != null)
                return new ObjectResult(grade);
            else
                return Json("Nenhuma grade encontrada.");
                //return NotFound();
        }
        */





    }

}
