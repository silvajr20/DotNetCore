using Flunt.Notifications;
using Flunt.Validations;

namespace ProductCatalog.ViewModels.ProdutoViewModels{

    public class EditorProdutoViewModel : Notifiable, IValidatable{

        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }        
        public int CategoriaId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract().HasMaxLen(Title, 120, "Title", "O título deve conter até 120 caracteres")
                .HasMinLen(Title, 3, "Title", "O título deve conter pelo menos 3 caractres")
                .IsGreaterThan(Price, 0, "Price", "O preço deve ser maior do que zero")

            );
        }
    }
}