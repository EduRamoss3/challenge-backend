

using WL.Domain.Entities.Base;

namespace WL.Domain.Entities
{
    public sealed class Wallet : Entity
    {
        public decimal Amount { get; private set; }

        public decimal GetBalance()
        {
            return Amount;
        }
        public decimal SetAmount(decimal amount)
        {
            Amount += amount;
            return Amount;
        }
    }
}
