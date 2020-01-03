using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.Controllers{

    public class PaginaInicialController : Controller{
        
        [HttpGet]
        [Route("")]
        public object Get(){
            return new { version = "Version 0.0.1" };
        }


    }
}
