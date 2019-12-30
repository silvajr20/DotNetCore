using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProdutoViewModels;

namespace ProductCatalog.ViewModels{

    public class ProdutoController : Controller{

        private readonly StoreDataContext _context;

        public ProdutoController(StoreDataContext context){
            _context = context;
        }

        [Route("v1/produtos")]
        [HttpGet]
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

        [Route("v1/produtos/{id}")]
        [HttpGet]
        public Produto Get(int id){
                return _context.Produtos.AsNoTracking().Where(x => x.id == id).FirstOrDefault();
        }

        [Route("v1/produtos")]
        [HttpPost]
        public ResultViewModel Post([FromBody] EditorProdutoViewModel model){
            model.Validate();
            if(model.Invalid)
                return new ResultViewModel
                {
                    Sucess = false,
                    Message = "Não foi possível cadastrar o produto.",
                    Data = model.Notifications
                };
            var produto = new Produto();
            produto.Title = model.Title;
            produto.CategoriaId = model.CategoriaId;
            produto.CreateDate = DateTime.Now;
            produto.Description = model.Description;
            produto.Image = model.Image;
            produto.LastUpdateDate = DateTime.Now;
            produto.Price = model.Price;
            produto.Quantity = model.Quantity;

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Sucess = true,
                Message = "Produto cadastrado com sucesso.",
                Data = produto
            };
           
        }

         [Route("v1/produtos")]
         [HttpPut]
         public ResultViewModel Put([FromBody] EditorProdutoViewModel model){
             model.Validate();
             if(model.Invalid)
                return new ResultViewModel
                {
                    Sucess = false,
                    Message = "Não foi possível alterar o produto.",
                    Data = model.Notifications
                };
            var produto = _context.Produtos.Find(model.id);
            produto.Title = model.Title;
            produto.CategoriaId = model.CategoriaId;
            //produto.CreateDate = DateTime.Now;
            produto.Description = model.Description;
            produto.Image = model.Image;
            produto.LastUpdateDate = DateTime.Now;
            produto.Price = model.Price;
            produto.Quantity = model.Quantity;

            _context.Entry<Produto>(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return new ResultViewModel{
                Sucess = true,
                Message = "Produto alterado com sucesso.",
                Data = produto    
            };


         }




    }
}