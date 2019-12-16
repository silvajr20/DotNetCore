using Payment.Context.Domain.Repositories;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.ValueObjects;

namespace Payment.Context.Tests.Mocks{
    public class FakeStudentRepository : IStudentRepository
    {
        public void createSubscrition(Student student)
        {
            throw new System.NotImplementedException();
        }
       
        public bool DocumentExist(string document)
        {
            if(document == "1234567891011")
                return true;
            return false;
        }
       
        public bool EmailExist(string email)
        {
            if(email == "teste@teste.com")
                return true;
            return false;
        }
    }
}