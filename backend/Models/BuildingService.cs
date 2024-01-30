using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Building Service, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Building Service has many Buildings. 
 * One Building Service on many Bills. 
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class BuildingService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Money { get; set; }

        // Many Buildings
        public ICollection<Building> Buildings { get; set; }

        //Many Bills
        public ICollection<Bill> Bills { get; set; }
    }
}
