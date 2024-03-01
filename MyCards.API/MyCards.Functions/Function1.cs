using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MyCards.Functions.Services;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using MyCards;
using Microsoft.Data.SqlClient;


namespace MyCards.Functions
{
    public class Function1
    {
        private IGuidGenerator _guidGenerator;

        public Function1(IGuidGenerator guidGenerator)
        {
            _guidGenerator = guidGenerator;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("GenerateGuid")]
        public async Task<IActionResult> GenerateGuid(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Guid")] HttpRequest req)
        {
            var newGuid = _guidGenerator.GenerateNewGuid();
            return new OkObjectResult(newGuid);
        }

        [FunctionName("DatabaseTriggerFunction")]
        public async Task Rundbo(
        [SqlTrigger("dbo.Notes", "NotebookDb")] IReadOnlyList<SqlChange<Note>> changes)
        {
            if (changes != null && changes.Count > 0)
            {
                foreach (var change in changes)
                {
                    Console.WriteLine(change.Operation);
                    await Console.Out.WriteLineAsync();
                }
                
            }
        }

               /* public static void Run([SqlTrigger("dbo.Cards", ConnectionStringSetting = "MyCardsDb")] IReadOnlyList<SqlChange> changes, ILogger log)
                {
                    if (changes != null && changes.Count > 0)
                    {
                        foreach (var change in changes)
                        {
                            log.LogInformation($"Change operation: {change.Operation}");
                            log.LogInformation($"Changed Id: {change.Current["Id"]}");
                            log.LogInformation($"Changed Title: {change.Current["Title"]}");
                            log.LogInformation($"Changed FileReference: {change.Current["FileReference"]}");
                            log.LogInformation($"Changed CreatedAt: {change.Current["CreatedAt"]}");
                        }
                    }
                }*/
    }
}
