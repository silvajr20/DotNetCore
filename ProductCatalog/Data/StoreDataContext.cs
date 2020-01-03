using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ProductCatalog.Data.Maps;
using ProductCatalog.Models;


namespace ProductCatalog.Data 
{
    public class StoreDataContext : DbContext {
        
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=CatProds;User ID=Sa; Password=senha%root123");
                               
        }


        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new CategoriaMap());

        }


    }
}
