using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Teste_MongoDB.Data;
using API_Teste_MongoDB.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_Teste_MongoDB.Controllers
{
    
        [Route("api/[controller]")]
        public class GradeController : Controller
        {
            private ConexaoContext _context;

            public GradeController(ConexaoContext context)
            {
                _context = context;
            }

            [HttpGet("grade/{id}")]
            public ActionResult<Grade> GetGrade(string id)
            {
                Grade grade = null;
                if (id.StartsWith("ID"))
                grade = _context.ObterItem<Grade>(id);

                if (grade != null)
                    return new ObjectResult(grade);
                else
                    return NotFound();
            }
        }



    }
