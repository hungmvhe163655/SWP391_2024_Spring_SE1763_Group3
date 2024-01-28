/**
 * Class for House Manager, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class HomeManager : BuildingResident
    {
        public ICollection<News> News { get; set; } 
        public ICollection<Building> Buildings { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
