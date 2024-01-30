using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Apartment, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Room is in one Building.
 * One Room has many Contracts.
 * One Room has many Bills.
 * One Room has many Tenants.
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

        // One Building 
        public int BuildingId { get; set; }
        public Building Building { get; set; }

        // Many Contracts
        public ICollection<Contract> Contracts { get; set; }

        // Many Bills
        public ICollection<Bill> Bills { get; set; }

        // Many Tenants
        public ICollection<Tenant> Tenants { get; set; }
    }
}
