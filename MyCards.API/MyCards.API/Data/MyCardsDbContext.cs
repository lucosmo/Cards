using Microsoft.EntityFrameworkCore;
using MyCards.API.Data.Entities;


namespace MyCards.API.Data
{
    public class MyCardsDbContext : DbContext
    {
        public DbSet<CardEntity> Cards => Set<CardEntity>();

        public MyCardsDbContext(DbContextOptions<MyCardsDbContext> options) : base(options)
        {

        }
    }
}
