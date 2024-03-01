using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCards.Functions.Services
{
    public class GuidGenerator : IGuidGenerator
    {
        public Guid GenerateNewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
