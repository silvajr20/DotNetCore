using System;

using Payment.Context.Domain.ValueObjects;

namespace Payment.Context.Domain.Entities {
   
    public class PayPalPayment : Payment {
        public PayPalPayment(string transactionCode,            
            DateTime paidDate,
            DateTime expireDate,
            decimal total, 
            decimal totalDate, 
            string payer, 
            Document document, 
            Adress adress, 
            Email email) : base(paidDate, 
                expireDate, 
                total, 
                totalDate, 
                payer, 
                document, 
                adress, 
                email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }


}