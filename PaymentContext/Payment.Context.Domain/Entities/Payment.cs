using System;
using Flunt.Validations;
using Payment.Context.Domain.ValueObjects;
using Payment.Context.Shared.Entities;

namespace Payment.Context.Domain.Entities {

    public abstract class  Payment : Entity {
        protected Payment(DateTime paidDate, DateTime? expireDate, decimal total, decimal totalDate, string payer, Document document, Adress adress, Email email)
        {
            number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalDate = totalDate;
            Payer = payer;
            Document = document;
            Adress = adress;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0, Total, "Payment.Total", "O valor pago deve ser 0.")
                .IsLowerOrEqualsThan(Total, TotalDate, "Payment.TotalDate", "O valor não pode ser menor do que o total."));
                
        }

        public string number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalDate { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Adress Adress { get; private set; }
        public Email Email { get; private set; }

    }

   


}