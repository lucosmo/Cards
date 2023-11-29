using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using MyCards.API.Repositories;

namespace MyCards.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly string _basePath = @"C:\project\mycards-api";
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var filename = file.FileName;

            using (var content = new MemoryStream())
            {
                await file.CopyToAsync(content);
                content.Position = 0;
                await _fileRepository.Upload(filename, content);
            }
            return new OkResult();
        }

        [HttpGet]
        [Route("{fileName}")] //route parameter
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var result = await _fileRepository.Download(fileName);
            
            return File(result, "application/octet-stream", fileName);
        }
        //route parameters
        //query parameters
        //to do query parameters
        //upload multiple files
    }
}
