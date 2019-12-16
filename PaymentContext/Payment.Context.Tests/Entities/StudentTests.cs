using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.Enums;
using Payment.Context.Domain.ValueObjects;

namespace PaymentContext.Tests
{

    [TestClass]
    public class StudentTests{

        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;        
        private readonly Adress _adress;


        //Construtor da própria classe para poder facilitar na inserção das informações do teste
        public StudentTests(){
            _name = new Name("Bruce", "Wayne");
            _document = new Document("12345678911", EDocumentType.CPF); 
            _email = new Email("email@email.com");
            _adress = new Adress("Rua x", "123", "Bairro a", "Berlândia", "MG","BR", "3840000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
            

        }

        //Validação de assinaturas com falha (estudante cadastrado com mais de uma assinatura)
        [TestMethod]
        public void VerificarAssinaturaInvalid(){            

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
                        
        }

        [TestMethod]
        public void VerificarAssinaturaValid(){            
            var payment = new PayPalPayment("12345678" ,DateTime.Now, DateTime.Now.AddDays(5), 10 , 10, "Wayne Corp", _document, _adress, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            
            Assert.IsTrue(_student.Valid);
        }



    }


}