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
    }
}
