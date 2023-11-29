namespace MyCards.API.Repositories
{
    public interface IFileRepository
    {
        Task Upload(string filename, Stream content);
        Task<Stream> Download(string filename);
        
    }
}
