using Azure.Storage.Blobs;

namespace MyCards.API.Repositories
{
    public class AzureBlobFileRepository : IFileRepository
    {
        private readonly string _connectionString;
        public AzureBlobFileRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Stream> Download(string filename)
        {
            var client = new BlobServiceClient(_connectionString);
            var containerClient = client.GetBlobContainerClient("cards");
            var blobClient = containerClient.GetBlobClient(filename);
            var result = await blobClient.DownloadContentAsync();
            return result.Value.Content.ToStream();
        }

        public async Task Upload(string filename, Stream content)
        {
            var client = new BlobServiceClient(_connectionString);
            var containerClient = client.GetBlobContainerClient("cards");
            var blobClient = containerClient.GetBlobClient(filename);
            await blobClient.UploadAsync(content);
        }

        public async Task Delete(string filename)
        {
            var client = new BlobServiceClient(_connectionString);
            var containerClient = client.GetBlobContainerClient("cards");
            var blobClient = containerClient.GetBlobClient(filename);
            await blobClient.DeleteAsync();
        }
        //delete
    }
}
