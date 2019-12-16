using System;
using Flunt.Notifications;

namespace Payment.Context.Shared.Entities{

    public abstract class Entity : Notifiable {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        

    }

}