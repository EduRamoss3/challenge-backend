

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WL.Domain.Entities.Base;

namespace WL.Domain.Entities
{
    public sealed class Wallet : Entity
    {
        public decimal Amount { get; private set; }
        public Guid UserId { get; private set; }
        [JsonIgnore]
        public User User { get;  set; }

        public decimal GetBalance()
        {
            return Amount;
        }
        public decimal SetAmount(decimal amount)
        {
            Amount += amount;
            return Amount;
        }
        public decimal MakeTransfer(decimal amount)
        {
            Amount -= amount;
            return Amount;
        }
        public Wallet(Guid userId, decimal amount)
        {
            UserId = userId;
            SetAmount(amount);
        }
        



    }
}
