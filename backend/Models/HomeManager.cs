/**
 * Class for Home Manager, this is use for entity framework to generate database.
 * This class NOT represent for a table in database. This class represent Inheritence
 * in both Database and in Class using Table per Hierarchy (TPH).
 * 
 * One Home Manager is author of many news.
 * One Home Manager manage many buildings.
 * One Home Manager receive many requests.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class HomeManager : BuildingResident
    {
        // Many News
        public ICollection<News> News { get; set; }

        // Many Buildings
        public ICollection<Building> Buildings { get; set; }

        // Many Requests
        public ICollection<Request> Requests { get; set; }
    }
}
