using System;
using Flunt.Notifications;
using Payment.Context.Domain.Commands;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.Enums;
using Payment.Context.Domain.Repositories;
using Payment.Context.Domain.Services;
using Payment.Context.Domain.ValueObjects;
using Payment.Context.Shared.Handlers;

namespace Payment.Context.Domain.Handlers{

    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {

        private readonly IStudentRepository _repository;

        private readonly IEmailService _iemailservice;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService){
            _repository = repository;
            _iemailservice = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {            
            // Verificar se o documento já está cadastrado
            command.Validate();
            if(command.Invalid){
                AddNotifications(command);
                return new CommandResults(false, "Não foi possível realizar a sua assinatura");
            }
            //Verificar se o e-mail já está cadastrado
            if(_repository.DocumentExist(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");
            
            if(_repository.EmailExist(command.email)){
                AddNotification("Email", "Este e-mail já está em uso.");
            }

            //Gerar os VOs
            var Name = new Name(command.FirstName, command.LastName);
            var Document = new Document(command.DocumentNumber, EDocumentType.CPF); 
            var Email = new Email(command.email);
            var Adress = new Adress(command.Street, command.StreetNumber, command.NightborHood, command.City, command.State, command.Country, command.ZipCode);
            
            //Gerar as entidades
            var student = new Student(Name, Document, Email);
            var subscription = new Subscription(DateTime.Now.AddMonths(5));
            var payment = new BoletoPayment(
                command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, 
                command.Total, 
                command.TotalDate,
                command.Payer, 
                new Document(command.DocumentNumber, command.payerDocumentType),
                command.Adress,
                command.Email
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            //Aplicar as validações
            AddNotifications(Name, Document, Email, Adress, student, payment, subscription);
            //Checar as validações
            if(Invalid)
                return new CommandResults(false, "Não foi possível realizar a assinatura.");
            //Salvar as informações
            _repository.createSubscrition(student);
            //Enviar e-mail de boas vindas
            _iemailservice.send(student.Name.ToString(), student.Email.Adress, "bem vindo a balt.io", "Sua assinatura foi realizada com sucesso." );
            //Retorna informações            
            return new CommandResults(true, "Assinatura cadastrada com sucesso.");
        }
    }
}