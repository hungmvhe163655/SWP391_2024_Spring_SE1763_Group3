using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class for Building Resident, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * <p>Picture will not be save on database but on some third party instead.
 * Therefore, in database will only save url</p>
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class BuildingResident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Picture will be save on GG drive instead
        public string PortraitPictureUrl { get; set; }

        // One Role
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
