namespace Backend.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid HomeMangerId { get; set; }

        public HomeManager HomeManager { get; set; }
        public ICollection<Building> Buildings { get; set; }
    }
}
