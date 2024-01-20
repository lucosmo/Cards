using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCards.API.Data.Dtos;
using MyCards.Frontend.Server.Mapper;
using MyCards.Frontend.Shared.Data;

namespace MyCards.Frontend.Server.Controllers
{
    //[Route("blazor/api/[controller]")]
    [Route("bff/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private HttpClient _apiClient, _fileClient;
        private readonly IHttpClientFactory _httpClientFactory;
        public CardController(IHttpClientFactory httpClientFactory)
        {
            //_apiClient = new HttpClient() { BaseAddress = new Uri("") };
            //_fileClient = new HttpClient() { BaseAddress = new Uri("") };
            _httpClientFactory = httpClientFactory;
           //_apiClient = _httpClientFactory.CreateClient("CardClient");
           //_fileClient = _httpClientFactory.CreateClient("FileClient");


        }
        [HttpGet]
        //[Route("Card")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _httpClientFactory.CreateClient("CardClient").GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var dtosResponse = await response.Content.ReadFromJsonAsync<List<CardDto>>();
                if(dtosResponse == null)
                {
                    return StatusCode(500);
                }
                var mappedData = dtosResponse.Select(item => CardMapper.MapCard(item, _httpClientFactory.CreateClient("FileClient").BaseAddress.ToString())).ToList();
                return Ok(mappedData);

            }

            return StatusCode(500);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCard(int id)
        {
            var response = await _httpClientFactory.CreateClient("CardClient").GetAsync($"{id}");
            if(response.IsSuccessStatusCode) 
            {
                var dtosResponse = await response.Content.ReadFromJsonAsync<CardDto>();
                if (dtosResponse == null)
                {
                    return StatusCode(500);
                }
                var mappedData = CardMapper.MapCard(dtosResponse, _httpClientFactory.CreateClient("FileClient").BaseAddress.ToString());
                                
                return Ok(mappedData);
            }
            return StatusCode(500);
        }
    }
}
