using Microsoft.AspNetCore.Mvc;
using MyCards.API.Data.Dtos;
using MyCards.API.Data.Entities;
using MyCards.API.Model;
using System.Collections.Immutable;

namespace MyCards.API.Repositories
{
    public class InMemoryCardRepository : ICardRepository
    {
        private List<CardEntity> cards = new List<CardEntity>();
        private int nextId = 1;
        public Task<CardDto> Create(CardEntity card)
        {
            card.Id = nextId++;
            cards.Add(card);
            CardDto resultCard = new CardDto(card.Id, card.Title, card.FileReference, card.CreatedAt);
            return Task.FromResult(resultCard);
        }
        
        public Task<List<CardEntity>> Get()
        {
            return Task.FromResult(cards);
        }

        public Task<CardEntity?> GetById(int id)
        {
            return Task.FromResult(cards.FirstOrDefault(i => i.Id == id));
        }

        public Task<CardEntity?> Update(int id, CardEntity newValuesCard)
        {
            var existingCard = cards.FirstOrDefault(i => i.Id == id);
            if (existingCard != null) 
            {
                existingCard.Title = newValuesCard.Title;
                var resultCardEntity = new CardEntity(existingCard.Id, existingCard.Title, existingCard.FileReference, existingCard.CreatedAt);
                return Task.FromResult<CardEntity?>(resultCardEntity);
            }
            else
            {
                return Task.FromResult<CardEntity?>(null);
            }
            
        }

        public Task<CardEntity?> Remove(int id) 
        {
            var existingCard = cards.FirstOrDefault(i => i.Id == id);
            if (existingCard != null)
            {
                var isRemoved = cards.Remove(existingCard);
                //var removedCardDto = new CardDto(existingCard.Id, existingCard.Title, existingCard.FileReference, existingCard.CreatedAt);
                return isRemoved ? Task.FromResult<CardEntity?>(existingCard) : Task.FromResult<CardEntity?>(null);
            }
            else
            {
                return Task.FromResult<CardEntity?>(null);
            }
        }
    }
}
