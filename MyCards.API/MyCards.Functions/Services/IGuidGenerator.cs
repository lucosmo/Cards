using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCards.Functions.Services
{
    public interface IGuidGenerator
    {
        Guid GenerateNewGuid();

    }
}
