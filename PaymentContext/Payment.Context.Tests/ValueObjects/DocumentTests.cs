using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.Enums;
using Payment.Context.Domain.ValueObjects;

namespace PaymentContext.Tests
{

    [TestClass]
    public class DocumentTests{
              
        //Testar CNPJ inválido
        [TestMethod]  
        public void testarCNPJInvalid(){
            var doc = new Document("1234567891111", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        //Testar CNPJ válido
        [TestMethod]  
        public void testarCNPJvalid(){
            var doc = new Document("12345678911111", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        //Testar CPF inválido
        [TestMethod] 
        [DataTestMethod]
        [DataRow("1234567891")]
        [DataRow("1234567892")]
        [DataRow("1234567893")]
        [DataRow("1234567894")]
        public void testarCPFinvalid(string cpf){
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        //Testar CPF válido
        [TestMethod] 
        public void testarCPFvalid(){
            var doc = new Document("12345678911", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }




    }

}