namespace MyCards.API.Model
{
    public class Card
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string FileReference { get; set; }
        public DateTime CreatedAt { get; set; }


        public Card()
        {
        }
        public Card(int? id, string title, string fileReference, DateTime createdAt)
        {
            this.Id = id;
            this.Title = title;
            this.FileReference = fileReference;
            this.CreatedAt = createdAt;
        }
    }
}
