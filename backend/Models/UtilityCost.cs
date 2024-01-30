/**
 * Class for Utility Cost, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Utility Cost has one Bill.
 * One Utility Cost has one Utility Cost Type.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class UtilityCost
    {
        public Guid Id { get; set; }
        public int PreviousMetric { get; set; }
        public int NewMetric { get; set; }

        // One Bill
        public Guid BillId { get; set; }
        public Bill Bill { get; set; }

        // One Utility Cost Type
        public int UtilityCostTypeId { get; set; }
        public UtilityCostType UtilityCostType { get; set; }
        
    }
}
