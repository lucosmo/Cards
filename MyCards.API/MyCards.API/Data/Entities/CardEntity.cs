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
            this.Id = id;
            this.Title = title;
            this.FileReference = fileReference;
            this.CreatedAt = createdAt;
        }
    }
}
