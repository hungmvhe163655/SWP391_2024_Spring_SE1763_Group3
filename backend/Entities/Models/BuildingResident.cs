using Entities.Base;
using Microsoft.AspNetCore.Identity;
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
    public class BuildingResident : IdentityUser, IEntitySoftDelete
    {
        public string FullName { get; set; } = null!;
        public bool IsMale { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Picture will be save on GG drive instead
        [MaxLength(1000)]
        public string? PortraitPictureUrl { get; set; } = null!;
    }
}
