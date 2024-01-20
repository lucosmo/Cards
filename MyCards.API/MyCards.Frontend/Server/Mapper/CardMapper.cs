using MyCards.API.Data.Dtos;
using MyCards.Frontend.Shared.Data;
using System;

namespace MyCards.Frontend.Server.Mapper
{
    public class CardMapper
    {
       /* public static CardData MapCard(int id, string title, string fileReference, DateTime createdAt, bool fileLinked, string url)
        {
            return new CardData()
            {
                Id = id,
                Title = title,
                FileReference = fileReference,
                CreatedAt = createdAt,
                FileLinked = fileLinked,
                FileUrl = GenerateUrl(url, fileReference, fileLinked)
            };
        }*/
        public static CardData MapCard(CardDto cardDto, string url)
        {
            return new CardData()
            {
                Id = cardDto.Id,
                Title = cardDto.Title,
                FileReference = cardDto.FileReference,
                CreatedAt = cardDto.CreatedAt,
                FileLinked = cardDto.FileLinked,
                FileUrl = GenerateUrl(url, cardDto.FileReference, cardDto.FileLinked)
            };
        }
        private static string GenerateUrl(string url, string fileReference, bool fileLinked) 
        {
            return !fileLinked || string.IsNullOrEmpty(url) || string.IsNullOrEmpty(fileReference) ? string.Empty : url+fileReference;
        }
    }
}
