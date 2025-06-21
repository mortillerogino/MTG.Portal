using MTG.Application.Enums;

namespace MTG.API.Models
{
    public class CreateCardRequest
    {
        public required string Name { get; set; }
        public required string Set { get; set; }
        public required int BinderId { get; set; }
        public required int Page { get; set; }
        public required IEnumerable<MtgTypes> MtgTypes { get; set; }
        public required IEnumerable<MtgColors> MtgColors { get; set; }
    }
}
