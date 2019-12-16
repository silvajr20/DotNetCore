using Flunt.Validations;
using PaymentContext.Shared.ValueObject;

namespace Payment.Context.Domain.ValueObjects{

    public class Adress : ValueObject{
        
        public Adress(string street, string number, string nightborHood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            NightborHood = nightborHood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Adress.Street", "O nome da rua deve conter no mínimo 3 caractéres."));


        }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string NightborHood { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }
    }
    
}