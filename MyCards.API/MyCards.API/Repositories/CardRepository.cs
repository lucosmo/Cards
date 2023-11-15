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

        public async Task<CardEntity?> GetById(int id)
        {
            return await _cardsDbContext.Cards.FindAsync(id);
        }

        public async Task<CardEntity?> Remove(int id)
        {
            var cardToRemove = await _cardsDbContext.Cards.FindAsync(id);

            if (cardToRemove != null)
            {
                _cardsDbContext.Cards.Remove(cardToRemove);
                await _cardsDbContext.SaveChangesAsync();
            }

            return cardToRemove;
        }

        public async Task<CardEntity?> Update(CardEntity newValuesCard)
        {
            var cardToUpdate = await _cardsDbContext.Cards.FindAsync(newValuesCard.Id);

            if (cardToUpdate != null)
            {
                cardToUpdate.Title = newValuesCard.Title;

                await _cardsDbContext.SaveChangesAsync();
            }

            return cardToUpdate;
        }
    }
}
