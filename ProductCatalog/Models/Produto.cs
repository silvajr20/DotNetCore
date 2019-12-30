using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate  { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


    }
}