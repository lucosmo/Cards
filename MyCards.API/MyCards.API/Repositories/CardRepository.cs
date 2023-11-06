using Microsoft.EntityFrameworkCore;
using MyCards.API.Data;
using MyCards.API.Data.Entities;

namespace MyCards.API.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly MyCardsDbContext _cardsDbContext;
        public CardRepository(MyCardsDbContext dbContext) 
        {
            _cardsDbContext = dbContext;
        }
        public async Task<CardEntity> Create(CardEntity card)
        {
            var createdCard = await _cardsDbContext.Cards.AddAsync(card);
            await _cardsDbContext.SaveChangesAsync();
            return createdCard.Entity;
        }

        public Task<List<CardEntity>> Get()
        {
            return _cardsDbContext.Cards.ToListAsync();
        }

        public Task<CardEntity?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CardEntity?> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CardEntity?> Update(CardEntity newValuesCard)
        {
            throw new NotImplementedException();
        }
    }
}
