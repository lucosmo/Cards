using MyCards.API.Model;

namespace MyCards.API.Repositories
{
    public interface ICardRepository
    {
        Task<List<Card>> Get();
        Task<Card?> GetById(int id);
        Task<Card> Create(Card card);

    }
}
