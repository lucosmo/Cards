using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCards.Frontend.Shared.Data
{
    public class CardData
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FileReference { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool FileLinked { get; set; }
    }
}
