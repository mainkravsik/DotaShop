using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}