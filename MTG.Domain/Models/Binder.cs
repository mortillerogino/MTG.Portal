namespace MTG.Domain.Models
{
    public class Binder
    {
        public int Id { get; set; } // Primary Key
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }

        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
