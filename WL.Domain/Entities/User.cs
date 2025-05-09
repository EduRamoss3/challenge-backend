

using WL.Domain.Entities.Base;

namespace WL.Domain.Entities
{
    public class User : Entity
    {
        public Guid Uid { get; set; }
        public string? Name { get; private set; }
        public Wallet? Wallet { get; private set; }

        public Message SetWallet(Wallet wallet)
        {
            Message message = new(string.Empty, false);
            // Se já não existir uma carteira, atribui
            if (Wallet == null)
            {
                Wallet = wallet;
                message.Content = "Success assigned";

            }
            else
            {
                message.Content = "Already exist on wallet for this user";
            }
            return message;
           
        }

        public User(Guid uid, string? name)
        {
            Uid = uid;
            Name = name;
        }
    }
}
