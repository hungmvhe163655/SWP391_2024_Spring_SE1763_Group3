/**
 * Class for House Manager, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class HouseManager
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string PortraitPictureUrl { get; set; }
        public ICollection<Building> Buildings { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
