using System;

using Payment.Context.Domain.ValueObjects;

namespace Payment.Context.Domain.Entities {
 
    public class BoletoPayment : Payment {
        public BoletoPayment(string barCode, string boletoNumber,               
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
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
       
    }
