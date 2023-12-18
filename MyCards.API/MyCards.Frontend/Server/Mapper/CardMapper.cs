using MyCards.Frontend.Shared.Data;

namespace MyCards.Frontend.Server.Mapper
{
    public class CardMapper
    {
        public static CardData MapCard(int id, string title, string fileReference, DateTime createdAt, bool fileLinked)
        {
            return new CardData()
            {
                Id = id,
                Title = title,
                FileReference = fileReference,
                CreatedAt = createdAt,
                FileLinked = fileLinked
            };
        }
    }
}
