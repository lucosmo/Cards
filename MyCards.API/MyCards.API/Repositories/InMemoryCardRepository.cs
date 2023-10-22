using MyCards.API.Model;
using System.Collections.Immutable;

namespace MyCards.API.Repositories
{
    public class InMemoryCardRepository : ICardRepository
    {
        private List<Card> cards = new List<Card>();
        private int nextId = 1;
        public async Task<Card> Create(Card card)
        {
            card.Id = nextId++;
            await Task.Run(() => cards.Add(card)); 
            return card;
        }
        
        public async Task<List<Card>> Get()
        {
            return await Task.Run(()=> cards);
        }

        public async Task<Card?> GetById(int id)
        {
            return await Task.Run(() => cards.FirstOrDefault(i => i.Id == id));
        }
    }
}
