using Microsoft.AspNetCore.Mvc;
using MyCards.API.Model;
using System.Collections.Immutable;

namespace MyCards.API.Repositories
{
    public class InMemoryCardRepository : ICardRepository
    {
        private List<Card> cards = new List<Card>();
        private int nextId = 1;
        public Task<Card> Create(Card card)
        {
            card.Id = nextId++;
            cards.Add(card); 
            return Task.FromResult(card);
        }
        
        public Task<List<Card>> Get()
        {
            return Task.FromResult(cards);
        }

        public Task<Card?> GetById(int id)
        {
            return Task.FromResult(cards.FirstOrDefault(i => i.Id == id));
        }

        public Task<Card?> Update(int id, Card newValuesCard)
        {
            var existingCard = cards.FirstOrDefault(i => i.Id == id);
            if (existingCard != null) 
            {
                existingCard.Title = newValuesCard.Title;
                return Task.FromResult<Card?>(existingCard);
            }
            else
            {
                return Task.FromResult<Card?>(null);
            }
            
        }

        public Task<Card?> Remove(int id) 
        {
            var existingCard = cards.FirstOrDefault(i => i.Id == id);
            if (existingCard != null)
            {
                var isRemoved = cards.Remove(existingCard);
                return isRemoved ? Task.FromResult<Card?>(existingCard) : Task.FromResult<Card?>(null);
            }
            else
            {
                return Task.FromResult<Card?>(null);
            }
        }
    }
}
