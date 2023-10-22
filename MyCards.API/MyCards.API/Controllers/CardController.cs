using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(cards);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item =await _cardRepository.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Card newCard)
        {
            
            var createdCard = await _cardRepository.Create(newCard);

            return Ok(createdCard);
        }

       /* [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Card updatedCard)
        {
            var existingCard = cards.FirstOrDefault(i => i.id == id);
            if (existingCard == null)
                return NotFound();

            existingCard.title = updatedCard.title;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCard= cards.FirstOrDefault(i => i.id == id);
            if (existingCard == null)
                return NotFound();

            cards.Remove(existingCard);
            return NoContent();
        }*/
    }
}


