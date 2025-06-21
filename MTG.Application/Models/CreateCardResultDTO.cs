
namespace MTG.Application.Models
{
    public class CreateCardResultDTO : ResultDTO
    {
        public int MyProperty { get; set; }
        public string? Set { get; set; }
        public string? Name { get; set; }
        public int Id { get; set; }
        public string? Binder { get; set; }
        public int Page { get; set; }
        public IEnumerable<string> MtgCardTypes { get; set; } = new List<string>();
        public IEnumerable<string> MtgColors { get; set; } = new List<string>();
    }
}
