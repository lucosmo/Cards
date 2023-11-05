using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCards.API.Data.Dtos;
using MyCards.API.Data.Entities;
using MyCards.API.Model;
using MyCards.API.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace MyCards.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private ICardRepository _cardRepository;
        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cards = await _cardRepository.Get();
            var cardsDto = cards.Select(card => new CardDto(card.Id, card.Title, card.FileReference, card.CreatedAt));
            return Ok(cardsDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var card =await _cardRepository.GetById(id);
            if (card == null)
            {
                return NotFound();
            }
            else
            {
                var cardDto = new CardDto(card.Id, card.Title, card.FileReference, card.CreatedAt);
                return Ok(cardDto);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCardDto newCard)
        {

            //newCard.CreatedAt = DateTime.Now; 
            var newCardEntity = new CardEntity
            {
                Title = newCard.Title,
                FileReference = newCard.FileReference,
                CreatedAt = DateTime.Now
            };
            var createdCard = await _cardRepository.Create(newCardEntity);
            //CreateCardDto createdCardDto = new CreateCardDto(createdCard.Title, createdCard.FileReference);
            if (createdCard != null)
            {
                return Ok(createdCard);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCardDto newValuesCard)
        {
            var newValuesEntity = new CardEntity
            {
                Id = id,
                Title = newValuesCard.Title
             };
            var updatedCard = await _cardRepository.Update(id, newValuesEntity);
            if(updatedCard != null)
            {
                var updatedCardDto = new CardDto(
                    updatedCard.Id,
                    updatedCard.Title,
                    updatedCard.FileReference,
                    updatedCard.CreatedAt
                    );
                return Ok(updatedCardDto);
            }
            else
            {
                return NotFound();
            }
        }
            
        

       [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removedCard = await _cardRepository.Remove(id);
            if (removedCard != null) 
            {
                var removedCardDto = new CardDto(
                    removedCard.Id,
                    removedCard.Title,
                    removedCard.FileReference,
                    removedCard.CreatedAt
                    );
                return Ok(removedCardDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}


