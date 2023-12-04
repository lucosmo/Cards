using Microsoft.AspNetCore.Mvc;
using MyCards.API.Data.Dtos;
using MyCards.API.Data.Entities;
using MyCards.API.Repositories;

namespace MyCards.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private ICardRepository _cardRepository;
        private IFileRepository _fileRepository;
        public CardController(ICardRepository cardRepository, IFileRepository fileRepository)
        {
            _cardRepository = cardRepository;
            _fileRepository = fileRepository;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cards = await _cardRepository.Get();
            var cardsDto = cards.Select(card => card.CreateCardDto());
            return Ok(cardsDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var card = await _cardRepository.GetById(id);
            if (card == null)
            {
                return NotFound();
            }
            else
            {
                var cardDto = card.CreateCardDto();
                return Ok(cardDto);
            }

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> LinkFile(int id, IFormFile file)
        {
            var card = await _cardRepository.GetById(id);
            if (card == null)
            {
                return NotFound();
            }
            if(card.FileLinked)
            {
                return Conflict();
            }
            card.FileReference = Guid.NewGuid().ToString();
            card.FileLinked = true;
            var updatedCard = await _cardRepository.Update(card);
            if (updatedCard == null)
            {
                return StatusCode(500);
            }

            using (var content = new MemoryStream())
            {
                await file.CopyToAsync(content);
                content.Position = 0;
                await _fileRepository.Upload(card.FileReference, content);
            }
            return Ok(updatedCard);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCardDto newCard)
        {
            var newCardEntity = new CardEntity
            {
                Title = newCard.Title,
                FileReference = string.Empty,
                CreatedAt = DateTime.Now,
                FileLinked = false
            };
            var createdCard = await _cardRepository.Create(newCardEntity);
            var createdCardDto = createdCard.CreateCardDto();
            return Ok(createdCardDto);
            
            
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCardDto newValuesCard)
        {
            var newValuesEntity = new CardEntity
            { 
                Id = newValuesCard.Id,
                Title = newValuesCard.Title
             };
            var updatedCard = await _cardRepository.Update(newValuesEntity);
            if(updatedCard != null)
            {
                var updatedCardDto = updatedCard.CreateCardDto();
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
            //var removedCard = await _cardRepository.Remove(id);
            var cardToRemove = await _cardRepository.GetById(id);
            if (cardToRemove == null)
            {
                return NotFound();
            }
            if (cardToRemove.FileLinked)
            {
                await _fileRepository.Delete(cardToRemove.FileReference);
            }
            var removedCard = await _cardRepository.Remove(id);
            var removedCardDto = removedCard?.CreateCardDto();
            return Ok(removedCardDto);
            
        }
    }
}


