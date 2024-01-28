

#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Apartment, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * One room is in one apartment.
 * One room has many contracts.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomNo { get; set; }
        public string Size { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        //One relationship 
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Bill> Bills { get; set; }    
        public ICollection<Tenant> Tenant { get; set; }
    }
}
