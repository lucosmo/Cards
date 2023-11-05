using Microsoft.AspNetCore.Mvc;
using MyCards.API.Data.Dtos;
using MyCards.API.Data.Entities;
using MyCards.API.Model;

namespace MyCards.API.Repositories
{
    public interface ICardRepository
    {
        Task<List<CardEntity>> Get();
        Task<CardEntity?> GetById(int id);
        Task<CardDto> Create(CardEntity card);

        Task<CardEntity?> Update(int id, CardEntity newValuesCard);

        Task<CardEntity?> Remove(int id);
    }
}
