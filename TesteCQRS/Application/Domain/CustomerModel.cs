﻿using System;

namespace TesteCQRS.Application.Domain
{
    public class CustomerModel
    {
        public CustomerModel(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public CustomerModel(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public void SetName(string name) =>
            Name = name;


        public void SetEmail(string email) =>
            Email = email;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
