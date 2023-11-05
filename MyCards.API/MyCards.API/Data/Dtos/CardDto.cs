namespace MyCards.API.Data.Dtos
{
    public record CardDto(
        int Id,
        string Title,
        string FileReference,
        DateTime CreatedAt);
    
}
