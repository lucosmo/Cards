using MyCards.API.Data.Entities;


namespace MyCards.API.Repositories
{
    public interface ICardRepository
    {
        Task<List<CardEntity>> Get();
        Task<CardEntity?> GetById(int id);
        Task<CardEntity> Create(CardEntity card);

        Task<CardEntity?> Update(CardEntity newValuesCard);

        Task<CardEntity?> Remove(int id);
    }
}
