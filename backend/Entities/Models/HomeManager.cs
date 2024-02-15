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

namespace Entities.Models
{
    public class HomeManager : BuildingResident
    {
        // Many News
        public virtual ICollection<News> News { get; set; } = null!;

        // Many Buildings
        public virtual ICollection<Building> Buildings { get; set; } = null!;

        // Many Requests
        public virtual ICollection<Request> Requests { get; set; } = null!;
    }
}
