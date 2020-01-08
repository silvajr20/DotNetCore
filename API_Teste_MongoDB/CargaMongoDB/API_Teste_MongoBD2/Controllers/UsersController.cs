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
        private UsersContext _context;

        public UsersController(UsersContext context)
        {
            _context = context;
        }

        [HttpGet("users/{id}")]
        public ActionResult<Users> GetGrade(string id)
        {
            Users users = null;
            //if (id.StartsWith("GRAD"))
            users = _context.ObterItem<Users>(id);

            if (users != null)
                return new ObjectResult(users);
            else
                return Json("Nenhum usuario encontrado.");
                //return NotFound();

        }
    }


}