/**
 * Class for Tenant, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * Tenant has many bills.
 * Tenant has many contracts.
 *
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Address { get; set; }
        // Store on Google Drive so will save url to database
        public string PortraitPictureUrl { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
