using MyCards.API.Data.Dtos;

namespace MyCards.API.Data.Entities
{
    public class CardEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FileReference { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }


        public CardEntity()
        {

        }
        public CardEntity(int id, string title, string fileReference, DateTime createdAt)
        {
            Id = id;
            Title = title;
            FileReference = fileReference;
            CreatedAt = createdAt;
        }

        public CardDto CreateCardDto()
        {
            return new CardDto(Id, Title, FileReference, CreatedAt);
        }
    }
}
