using Payment.Context.Domain.Repositories;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.Services;

namespace Payment.Context.Tests.Mocks{
    public class FakeEmailService : IEmailService
    {
        public void send(string to, string email, string subjetct, string budy)
        {
            throw new System.NotImplementedException();
        }
    }
}