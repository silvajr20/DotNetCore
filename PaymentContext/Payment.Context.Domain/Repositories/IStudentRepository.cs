using Payment.Context.Domain.Entities;
using Payment.Context.Domain.ValueObjects;

namespace Payment.Context.Domain.Repositories{

    public interface IStudentRepository{

        bool DocumentExist(string document);

        bool EmailExist(string email);

        void createSubscrition(Student student);

    }
}