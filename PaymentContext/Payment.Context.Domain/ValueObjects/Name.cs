using Flunt.Validations;
using PaymentContext.Shared.ValueObject;

namespace Payment.Context.Domain.ValueObjects{

    public class Name : ValueObject {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve conter no mínimo 3 caractéres.")
                .HasMinLen(LastName, 3, "Name.LastName", "O sobrenome deve ter no mínimo 3 caractéres.")
                .HasMaxLen(FirstName, 30, "Name.FirstName", "O nome deve conter no máximo 30 caractéres."));

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString() {
            return $"{FirstName} {LastName}";
        }

    }

}