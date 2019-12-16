using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.ValueObjects;

namespace Payment.Context.Domain.Queries{
    [TestClass]
    public class StudentsQueriesTests{

        private IList<Student> _student;

        
        public StudentsQueriesTests(){ 
            for(var i = 0; i < 10; i++){
                _student.Add(new Student (
                new Name("Teste", i.ToString()),
                new Document("11111111" + i.ToString(), Enums.EDocumentType.CPF),
                new Email(i.ToString() + "@teste.com")
                ));
            }
        }
        
        [TestMethod]
        public void validaNuloEmDocumentoNaoExistente(){
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var studn = _student.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);

        }

        [TestMethod]
        public void validaNuloEmDocumentoExistente(){
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var studn = _student.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);

        }

    }
}