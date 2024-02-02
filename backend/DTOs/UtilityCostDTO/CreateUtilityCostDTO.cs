using Backend.Models;

namespace Backend.DTOs.UtilityCostDTO
{
    public class CreateUtilityCostDTO
    {
        public int PreviousMetric { get; set; }
        public int NewMetric { get; set; }
        public Guid BillId { get; set; }
        public int UtilityCostTypeId { get; set; }
    }
}
