using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProdutoViewModels;

namespace ProductCatalog.Repositorios{
    public class ProdutoRepositorio
    {
        private readonly StoreDataContext _context;

        public ProdutoRepositorio(StoreDataContext context){
            _context = context;
        }


        //Listar todos os produtos
        public IEnumerable<ListProdutoViewModel> Get(){
            return _context.Produtos
                        .Include(x => x.Categoria)
                        .Select(x => new ListProdutoViewModel
                        {
                            id = x.id,
                            Title = x.Title,
                            Price = x.Price,
                            Categoria = x.Categoria.Title,
                            CategoriaId = x.Categoria.Id

                        }).AsNoTracking()
                        .ToList();
        }
        
        public Produto Get(int id){
            return _context.Produtos.AsNoTracking().Where(x => x.id == id).FirstOrDefault();            
        }

        
        public void Save(Produto produto){
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto){
            _context.Entry<Produto>(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        


    }     
}