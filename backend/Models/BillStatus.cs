/**
 * Class for Bill Status, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Bill Status has many Bills.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class BillStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        // Many Bills
        public ICollection<Bill> Bills { get; set; }
    }
}
