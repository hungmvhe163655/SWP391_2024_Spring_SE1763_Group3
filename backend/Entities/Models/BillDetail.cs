using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class BillDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int PreviousWaterReading { get; set; }
        public int CurrentWaterReading { get; set; }
        public int PreviousElectricityReading { get; set; }
        public int CurrentElectricityReading { get; set; }

        [Column(TypeName = "money")]
        public decimal WaterPricePerMonth { get; set; }
        [Column(TypeName = "money")]
        public decimal ElectricityPricePerMonth { get; set; }
        [Column(TypeName = "money")]
        public decimal RoomRentPrice { get; set; }

        public Guid BillId { get; set; }
        public virtual Bill Bill { get; set; } = null!;
    }
}
