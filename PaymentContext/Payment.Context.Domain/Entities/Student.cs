using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using Payment.Context.Domain.ValueObjects;
using Payment.Context.Shared.Entities;

namespace Payment.Context.Domain.Entities {

    public class Student : Entity {
        
        private IList<Subscription> _subscription;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;            
            _subscription = new List<Subscription>();

            AddNotifications(name, document, email);
        }
        
        public Name Name { get; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }                
        public string Adress { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subscription.ToArray();} }
    
    
        public void AddSubscription(Subscription subscription){
            
            var hasSubscriptionActive = false;
            foreach(var sub in Subscriptions){
                if(sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já possui uma assinatura.")
                .AreNotEquals(0, subscription.Payaments.Count, "Student.Payment.Subscription"  , "Não consta nenhum pagamento para a sua assinatura."));
                
            
            _subscription.Add(subscription);

        }

    
    }
      

}