using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG.Domain.Models
{
    public class MtgCard : Card
    {
        public string Set { get; set; } = null!;
        public ICollection<MtgColor> MtgColors { get; set; } = new List<MtgColor>();
        public ICollection<MtgType> MtgTypes { get; set; } = new List<MtgType>();
    }
}
