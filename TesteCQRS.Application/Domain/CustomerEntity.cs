using System;

namespace TesteCQRS.Application.Domain
{
    public class CustomerEntity
    {
        public CustomerEntity(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
        public CustomerEntity(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        public CustomerEntity(Guid id) 
            => Id = id;
        

        public void SetName(string name) =>
            Name = name;
        public void SetEmail(string email) =>
            Email = email;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
