using System.ComponentModel.DataAnnotations;

/**
 * Class for Bill Status, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Bill Status has many Bills.
 * 
 * @author HungMV
 */

namespace Entities.Models
{
    public class BillStatus
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = null!;

        // Many Bills
        public virtual ICollection<Bill> Bills { get; set; } = null!;
    }
}
