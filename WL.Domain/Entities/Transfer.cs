
using WL.Domain.Entities.Base;

namespace WL.Domain.Entities
{
    public sealed class Transfer : Entity
    {
        public Guid UidOfCreator { get; set; }
        public Guid UidOfReceptor { get; set; }
        public Guid IdWalletCreator { get; set; }
        public Guid IdWalletReceptor { get; set; }
        public DateTime Date { get; set; } 
        public string NameReceptingUser { get; set; }
       
        public decimal Amount { get; private set; }

        public Transfer(Guid uidOfCreator, Guid uidOfReceptor, DateTime date, decimal amount, Guid idWalletCreator, Guid idWalletReceptor, string nameReceptingUser)
        {
            UidOfCreator = uidOfCreator;
            UidOfReceptor = uidOfReceptor;
            Date = date;
            SetAmount(amount);
            IdWalletCreator = idWalletCreator;
            IdWalletReceptor = idWalletReceptor;
            NameReceptingUser = nameReceptingUser;
        }

      

        private void SetAmount(decimal amount)
        {
            Amount = amount;
        }
    }
}
