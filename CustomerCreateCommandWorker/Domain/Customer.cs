using System;

namespace CustomerCreateCommandWorker.Domain
{
    internal class Customer
    {
        public Customer(Guid Id, string name, string email)
        {
            CustomerId = Id.ToString();
            Name = name;
            Email = email;
        }

        public string CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
