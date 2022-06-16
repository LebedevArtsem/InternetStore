using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InternetStore.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public User()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        public User(string email, string password)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Email = email;
            Password = password;
        }
    }
}
