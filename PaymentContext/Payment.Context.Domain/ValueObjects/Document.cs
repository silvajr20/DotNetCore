
using Flunt.Validations;
using Payment.Context.Domain.Enums;
using PaymentContext.Shared.ValueObject;

namespace Payment.Context.Domain.ValueObjects{

    public class Document : ValueObject{
        public Document(string number, EDocumentType type)
        {
            Number=number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(validate(), "Document.Number", "Documento inválido."));
        }

        public Document(string documentNumber, string paymentnumber)
        {
        }

        public string Number { get; private set; }

        public EDocumentType Type { get; set; }


        public bool validate(){            
            if(Type == EDocumentType.CNPJ && Number.Length == 14){
                return true;
            }
            if(Type == EDocumentType.CPF && Number.Length == 11){
                return true;
            }
            
            return false;
        }

    }

}