using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProdutoViewModels;

namespace ProductCatalog.ViewModels.ProdutoViewModels{
    public class ResultViewModel{
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }


    }
}