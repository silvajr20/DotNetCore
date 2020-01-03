namespace ProductCatalog.ViewModels.ProdutoViewModels{

    public class ListProdutoViewModel{

        public int id { get; set; }
        public string Title { get; set; }       
        public decimal Price { get; set; }                 
        public int CategoriaId { get; set; }        
        public string Categoria { get; set; }


    }

}