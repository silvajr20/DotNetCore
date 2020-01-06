using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Teste_MongoBD2.Models;
using API_Teste_MongoDB.Data;
using Microsoft.AspNetCore.Mvc;

namespace API_Teste_MongoBD2.Controllers
{
    // Rota do navegador:       https://localhost:5001/api/Users/users/1
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private ConexaoContext _context;

        public UsersController(ConexaoContext context)
        {
            _context = context;
        }

        [HttpGet("users/{codigo}")]
        public ActionResult<Users> GetGrade(string codigo)
        {
            Users users = null;
            //if (id.StartsWith("GRAD"))
            users = _context.ObterItem<Users>(codigo);

            if (users != null)
                return new ObjectResult(users);
            else
                return NotFound();
        }
    }


}