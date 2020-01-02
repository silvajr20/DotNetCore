using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositorios;
using ProductCatalog.ViewModels.ProdutoViewModels;

namespace ProductCatalog.ViewModels{

    public class ProdutoController : Controller{

        private readonly ProdutoRepositorio _produtoRepositorio;

        public ProdutoController(ProdutoRepositorio produtoRepositorio){
            _produtoRepositorio = produtoRepositorio;
        }

        [Route("v1/produtos")]
        [HttpGet]
        [ResponseCache(Duration=60)] //Essa estratégia diminui a carga de trabalho do servidor
        public IEnumerable<ListProdutoViewModel> Get(){
            return _produtoRepositorio.Get();
        }

        [Route("v1/produtos/{id}")]
        [HttpGet]
        public Produto Get(int id){
                return _produtoRepositorio.Get(id);
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

            //Versao sem repositorio
            //_context.Produtos.Add(produto);
            //_context.SaveChanges();

            //Versao com repositorio
            _produtoRepositorio.Save(produto);

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
            var produto = _produtoRepositorio.Get(model.id);
            produto.Title = model.Title;
            produto.CategoriaId = model.CategoriaId;
            //produto.CreateDate = DateTime.Now;
            produto.Description = model.Description;
            produto.Image = model.Image;
            produto.LastUpdateDate = DateTime.Now;
            produto.Price = model.Price;
            produto.Quantity = model.Quantity;


            //Versao sem repositorio
            //_context.Entry<Produto>(produto).State = EntityState.Modified;
            //_context.SaveChanges();

            //Versao com repositorio
            _produtoRepositorio.Update(produto);

            return new ResultViewModel{
                Sucess = true,
                Message = "Produto alterado com sucesso.",
                Data = produto    
            };
         }



    }
}