

using System.Text.Json.Serialization;
using WL.Domain.Entities.Base;

namespace WL.Domain.Entities
{
    public class User : Entity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [JsonIgnore]
        public List<Wallet> Wallets { get; set; }
     
        public User(string? name, string? email, string? password)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
