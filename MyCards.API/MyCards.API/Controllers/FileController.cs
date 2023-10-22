using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace MyCards.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly string _basePath = @"C:\project\mycards-api";
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            
            using (var fileStream = System.IO.File.Create($"{_basePath}\\{file.FileName}"))
            {
                await file.CopyToAsync(fileStream);
            }
            return new OkResult();
        }

        [HttpGet]
        [Route("{fileName}")] //route parameter
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var result = await System.IO.File.ReadAllBytesAsync($"{_basePath}\\{fileName}");
            return new FileContentResult(result, "application/octet-stream");
        }
        //route parameters
        //query parameters
        //to do query parameters
        //upload multiple files
    }
}
