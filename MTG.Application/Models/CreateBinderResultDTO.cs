namespace MTG.Application.Models
{
    public class CreateBinderResultDTO : ResultDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
