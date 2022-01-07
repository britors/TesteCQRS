using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CustomerCreateCommandWorker.Domain
{
    internal class Customer
    {
        public Customer(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        [BsonId]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
