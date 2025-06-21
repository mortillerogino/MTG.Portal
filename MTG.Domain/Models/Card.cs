
namespace MTG.Domain.Models
{
    public abstract class Card
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }

        public int BinderId { get; set; }

        public Binder Binder { get; set; } = null!;
    }
}
