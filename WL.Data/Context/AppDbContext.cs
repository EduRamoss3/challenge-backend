using Microsoft.EntityFrameworkCore;
using WL.Domain.Entities;

namespace WL.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public void Seed()
        {
            // Verifica se já existem dados no banco de dados
            if (!Users.Any() && !Wallets.Any() && !Transfers.Any())
            {
                // Criando usuários fictícios
                var user1 = new User("John Doe Comf", "john.doerogers@example.com", Criptografer.DoubleEncode("password12345"));
                var user2 = new User("Jane Smith Roger", "jane.smithe@example.com", Criptografer.DoubleEncode("password12345"));

                // Adicionando os usuários ao DbSet
                Users.AddRange(user1, user2);

                // Salvando os usuários para gerar os IDs
                SaveChanges();

                // Criando carteiras para os usuários
                var wallet1 = new Wallet(user1.Id, 1000.00m); // 1000.00 para o John Doe
                var wallet2 = new Wallet(user2.Id, 500.00m);  // 500.00 para a Jane Smith

                // Adicionando as carteiras ao DbSet
                Wallets.AddRange(wallet1, wallet2);

                // Salvando as carteiras no banco para gerar os IDs
                SaveChanges();

                // Criando algumas transferências fictícias
                var transfer1 = new Transfer(user1.Id, user2.Id, DateTime.UtcNow, 200.00m, wallet1.Id, wallet2.Id, "Jane Smith Roger");
                var transfer2 = new Transfer(user2.Id, user1.Id, DateTime.UtcNow, 100.00m, wallet2.Id, wallet1.Id, "John Doe Comf");

                // Adicionando as transferências ao DbSet
                Transfers.AddRange(transfer1, transfer2);

                // Salvando as transferências no banco
                SaveChanges();
            }
        }
    }
}
