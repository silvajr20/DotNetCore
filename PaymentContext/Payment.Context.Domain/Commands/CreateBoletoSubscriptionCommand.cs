using System;
using Flunt.Notifications;
using Flunt.Validations;
using Payment.Context.Domain.Enums;
using Payment.Context.Domain.ValueObjects;
using Payment.Context.Shared.Commands;

namespace Payment.Context.Domain.Commands{

    public class CreateBoletoSubscriptionCommand : Notifiable , ICommand {

        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string DocumentNumber { get;  set; }
        public string Document { get;  set; }
        public EDocumentType payerDocumentType { get;  set; }
        public Adress Adress {get; set; }
        public Email Email {get; set; }        
        public string email { get; set; }
        public string BarCode { get;  set; }
        public string BoletoNumber { get;  set; }      
        public string Paymentnumber { get;  set; }        
        public DateTime PaidDate { get;  set; }
        public DateTime ExpireDate { get;  set; }
        public decimal Total { get;  set; }
        public decimal TotalDate { get;  set; }
        public string Payer { get;  set; }
        public string Street { get;  set; }
        public string StreetNumber { get;  set; }
        public string NightborHood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
        public string ZipCode { get;  set; }
       

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve conter no mínimo 3 caractéres.")
                .HasMinLen(LastName, 3, "Name.LastName", "O sobrenome deve ter no mínimo 3 caractéres.")
                .HasMaxLen(FirstName, 30, "Name.FirstName", "O nome deve conter no máximo 30 caractéres."));


        }
    }
}