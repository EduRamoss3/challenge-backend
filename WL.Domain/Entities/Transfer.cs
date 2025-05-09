
using WL.Domain.Entities.Base;

namespace WL.Domain.Entities
{
    public sealed class Transfer : Entity
    {
        public Guid UidOfCreator { get; set; }
        public Guid UidOfReceptor { get; set; }
        public DateTime Date { get; set; } 
        public decimal Amount { get; private set; }

        public Transfer(Guid uidOfCreator, Guid uidOfReceptor, DateTime date, decimal amount)
        {
            UidOfCreator = uidOfCreator;
            UidOfReceptor = uidOfReceptor;
            Date = date;
            SetAmount(amount);

        }
        private void SetAmount(decimal amount)
        {
            Amount = amount;
        }
    }
}
