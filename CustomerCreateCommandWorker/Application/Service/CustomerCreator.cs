using CustomerCreateCommandWorker.Domain;
using MongoDB.Driver;

namespace CustomerCreateCommandWorker.Application.Service
{
    internal class CustomerCreator
    {
        private readonly IMongoCollection<Customer> _customers;
        public CustomerCreator()
        {
            var client = new MongoClient("mongodb://mongodb:27017");
            var database = client.GetDatabase("customerapi");
            _customers = database.GetCollection<Customer>("customer");
        }
        public void Create(Customer customer)
            => _customers.InsertOne(customer);
    }
}
