/**
 * Class for Apartment, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * One apartment have many rooms.
 * One apartment have many managers.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int HouseManagerId { get; set; }
        public HouseManager HouseManager { get; set; }
        //Many relationship 
        public ICollection<Room> Rooms { get; set; }
        public ICollection<ApartmentPicture> Pictures { get; set; }
    }
}
