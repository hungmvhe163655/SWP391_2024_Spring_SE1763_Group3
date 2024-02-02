namespace Backend.DTOs.UtilityCostDTO
{
    public class UpdateUtilityCostDTO
    {
        public Guid Id { get; set; }
        public int PreviousMetric { get; set; }
        public int NewMetric { get; set; }
        public Guid BillId { get; set; }
        public int UtilityCostTypeId { get; set; }
    }
}
