using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCards.API.Data.Dtos;
using MyCards.Frontend.Shared.Data;

namespace MyCards.Frontend.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private HttpClient _apiClient;
        public CardController()
        {
            _apiClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7025/api/Card") };
         
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _apiClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var dtosResponse = await response.Content.ReadFromJsonAsync<List<CardDto>>();
                if(dtosResponse == null)
                {
                    return StatusCode(500);
                }
                var mappedData = dtosResponse.Select(item => new CardData()
                {
                    Id = item.Id,
                    Title = item.Title,
                    FileReference = item.FileReference,
                    CreatedAt = item.CreatedAt,
                    FileLinked = item.FileLinked

                }).ToList();
                return Ok(dtosResponse);

            }

            return StatusCode(500);
        }
    }
}
