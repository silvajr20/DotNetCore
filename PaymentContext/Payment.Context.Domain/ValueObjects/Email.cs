using Flunt.Validations;
using PaymentContext.Shared.ValueObject;

namespace Payment.Context.Domain.ValueObjects{

    public class Email : ValueObject {
        public Email(string adress)
        {
            Adress = adress;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Adress, "Email.Adress", "E-mail inserido inválido."));
        
        }

        public string Adress { get; private set; }
        
    
    }

}