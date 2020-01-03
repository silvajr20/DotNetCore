using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoNovoController : Controller
    {
             
        private ConexaoContext _context;

        public ProdutoNovoController(ConexaoContext context)
        {
            _context = context;
        }

        [HttpGet("produtos/{codigo}")]
        public ActionResult<Produto> GetProduto(string codigo)
        {
            Produto prod = null;
            if (codigo.StartsWith("PROD"))
                prod = _context.ObterItem<Produto>(codigo);

            if (prod != null)
                return new ObjectResult(prod);
            else
                return NotFound();
        }


    }

}


