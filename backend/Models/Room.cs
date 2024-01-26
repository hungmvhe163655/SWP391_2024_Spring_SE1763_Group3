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
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public string Size { get; set; }
        //Money is used type decimal
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        //One relationship 
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<RoomService> RoomServices { get; set; }
    }
}
