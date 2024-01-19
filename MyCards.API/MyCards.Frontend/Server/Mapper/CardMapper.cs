using MyCards.Frontend.Shared.Data;

namespace MyCards.Frontend.Server.Mapper
{
    public class CardMapper
    {
        public static CardData MapCard(int id, string title, string fileReference, DateTime createdAt, bool fileLinked, string url)
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
        }

        private static string GenerateUrl(string url, string fileReference, bool fileLinked) 
        {
            return !fileLinked || string.IsNullOrEmpty(url) || string.IsNullOrEmpty(fileReference) ? string.Empty : url+fileReference;
        }
    }
}
