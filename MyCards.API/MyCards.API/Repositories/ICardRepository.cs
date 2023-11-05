using Microsoft.AspNetCore.Mvc;
using MyCards.API.Model;

namespace MyCards.API.Repositories
{
    public interface ICardRepository
    {
        Task<List<Card>> Get();
        Task<Card?> GetById(int id);
        Task<Card> Create(Card card);

        Task<Card?> Update(int id, Card newValuesCard);

        Task<Card?> Remove(int id);
    }
}
