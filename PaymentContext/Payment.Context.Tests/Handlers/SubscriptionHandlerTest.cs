using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Context.Domain.Commands;
using Payment.Context.Domain.Enums;
using Payment.Context.Domain.Handlers;
using Payment.Context.Tests.Mocks;

namespace Payment.Context.Tests.Handlers{

    public class SubscriptionHandlerTest{

        [TestMethod]
        public void retornarErrorComDumentoExistente(){
            var Handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Nome";
            command.LastName ="Sobrenome";
            command.DocumentNumber ="12345678910"; 
            command.Document ="123456"; 
            command.payerDocumentType = EDocumentType.CPF;                   
            command.email ="teste@teste.com"; 
            command.BarCode ="1234567891"; 
            command.BoletoNumber ="12345";       
            command.Paymentnumber ="12345";               
            command.ExpireDate =DateTime.Now.AddMonths(1); 
            command.Total = 60; 
            command.TotalDate = 60; 
            command.Payer ="Bruce"; 
            command.Street ="Rua x"; 
            command.StreetNumber ="1234"; 
            command.NightborHood ="Bairro teste"; 
            command.City ="Cidade teste"; 
            command.State = "SP"; 
            command.Country ="Brasil"; 
            command.ZipCode ="38450000";

            Handler.Handle(command);
            Assert.AreEqual(false, Handler.Valid);

        }




    }

}