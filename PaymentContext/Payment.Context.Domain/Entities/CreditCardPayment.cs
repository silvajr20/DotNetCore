using System;

using Payment.Context.Domain.ValueObjects;

namespace Payment.Context.Domain.Entities {
           
    public class CreditCardPayment : Payment {
        public CreditCardPayment(string cardHolderName,
                string cardName, 
                string lastTransactionNumber,string transactionCode,               
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
            CardHolderName = cardHolderName;
            CardName = cardName;
            LastTransactionNumber = lastTransactionNumber;
        }


        public string CardHolderName { get; private set; }
        public string  CardName { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }


}
