using Entities.Base;
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

namespace Entities.Models
{
    public class BuildingResident : IEntitySoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string FullName { get; set; } = null!;

        [MaxLength(100)]
        public string PhoneNumber { get; set; } = null!;

        [MaxLength(100)]
        public string Password { get; set; } = null!;
        public bool IsMale { get; set; }

        [MaxLength(100)]
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Picture will be save on GG drive instead
        [MaxLength(1000)]
        public string PortraitPictureUrl { get; set; } = null!;

        // One Role
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;
    }
}
