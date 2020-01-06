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
            private ConexaoContext _context;

            public GradeController(ConexaoContext context)
            {
                _context = context;
            }

            [HttpGet("grades/{codigo}")]
            public ActionResult<Grade> GetGrade(string codigo)
            {
                Grade grade = null;
                //if (id.StartsWith("GRAD"))
                grade = _context.ObterItem<Grade>(codigo);

                if (grade != null)
                    return new ObjectResult(grade);
                else
                    return NotFound();
            }
        }



    }
