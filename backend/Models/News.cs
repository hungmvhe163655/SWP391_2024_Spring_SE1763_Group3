/**
 * Class for News, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One News is authored by one Home Manager.
 * One News for many Buildings.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class News
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // One Home Manager
        public Guid HomeMangerId { get; set; }
        public HomeManager HomeManager { get; set; }

        // Many Buildings
        public ICollection<Building> Buildings { get; set; }
    }
}
