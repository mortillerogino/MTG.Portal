using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG.Domain.Models
{
    public class MtgType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<MtgCard> MtgCards { get; set; } = new List<MtgCard>();
    }
}
