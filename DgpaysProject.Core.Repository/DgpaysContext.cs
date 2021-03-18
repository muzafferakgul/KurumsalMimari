using DgpaysProject.Core.Repository.Entity.Acquiring;
using DgpaysProject.Core.Repository.Entity.Issuing;
using DgpaysProject.Core.Repository.Entity.Transaction;
using Microsoft.EntityFrameworkCore;

namespace DgpaysProject.Core.Repository
{
    public class DgpaysContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MUZAFFER-PC\SQLEXPRESS;Database=DgpaysProject;Trusted_Connection=true;");
        }

        public DbSet<MerchantMaster> MerchantMaster { get; set; }
        public DbSet<TerminalMaster> TerminalMaster { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<CardType> CardType { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<CustomerEmail> CustomerEmail { get; set; }
        public DbSet<CustomerPhone> CustomerPhone { get; set; }
        public DbSet<TransactionDecline> TransactionDecline { get; set; }
        public DbSet<TransactionMaster> TransactionMaster { get; set; }
    }
}
