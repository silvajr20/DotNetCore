namespace PaymentContext.Tests {
    using global::Payment.Context.Domain.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Payment.Context.Tests
{

    [TestClass]
    public class CreateBoletoSubscriptionCommandTest{
              
        //Testar CNPJ inválido
        [TestMethod]  
        public void testarNomeInvalid(){
            
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "testeeee";

            command.Validate();

            Assert.AreEqual(false, command.Valid);           

        }

        



    }

}


}