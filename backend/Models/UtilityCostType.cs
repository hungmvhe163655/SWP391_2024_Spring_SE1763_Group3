using System.ComponentModel.DataAnnotations.Schema;
/**
 * Class for Utility Cost Type, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Utility Cost Type has many Utility Costs.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class UtilityCostType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "money")]
        public decimal PricePerUnit { get; set; }

        // Many Utility Costs
        public ICollection<UtilityCost> UtilityCosts { get; set; }
    }
}
