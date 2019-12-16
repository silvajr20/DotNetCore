namespace Payment.Context.Domain.Services{


    public interface IEmailService{
        void send(string to, string email, string subjetct, string budy);

    }

}