using Backend.Models;

namespace Backend.DTOs.NewsDTO
{
    public class CreateNewsDTO
    {
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
