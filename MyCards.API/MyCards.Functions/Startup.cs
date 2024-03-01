using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyCards.Functions.Services;
using System.Xml.Linq;

[assembly: FunctionsStartup(typeof(MyCards.Functions.Startup))]

namespace MyCards.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IGuidGenerator, GuidGenerator>();
            
        }
    }
}
