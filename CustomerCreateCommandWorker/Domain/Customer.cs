using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerCreateCommandWorker.Domain
{
    internal class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
