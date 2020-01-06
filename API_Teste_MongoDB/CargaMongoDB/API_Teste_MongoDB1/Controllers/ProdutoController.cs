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
        public class ProdutoController : Controller
        {

            private ConexaoContext _context;

            public ProdutoController(ConexaoContext context)
            {
                _context = context;
            }

            [HttpGet("web_grade/{id}")]
            public ActionResult<web_grade> GetGrade(int id)
            {
                web_grade grade = null;
                if (id.Equals("id"))
                    grade = _context.ObterItem<web_grade>(id);

                if (grade != null)
                    return new ObjectResult(grade);
                else
                    return NotFound();
            }


        }



    }
