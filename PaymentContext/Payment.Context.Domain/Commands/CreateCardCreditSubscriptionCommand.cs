using System;

using Flunt.Notifications;
using Payment.Context.Shared.Commands;

namespace Payment.Context.Domain.Commands{

    public class CreateCreditCardSubscriptionCommand : Notifiable , ICommand {

        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string DocumentNumber { get;  set; }
        public string CardHolderName { get;  set; }
        public string  CardName { get;  set; }
        public string LastTransactionNumber { get;  set; }   
        public string Paymentnumber { get;  set; }        
        public DateTime PaidDate { get;  set; }
        public DateTime ExpireDate { get;  set; }
        public decimal Total { get;  set; }
        public decimal TotalDate { get;  set; }
        public string Payer { get;  set; }
        public string Adress { get;  set; }
        public string Street { get;  set; }
        public string Number { get;  set; }
        public string NightborHood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }

        public void Validate()
        {
            
        }
    }

}
