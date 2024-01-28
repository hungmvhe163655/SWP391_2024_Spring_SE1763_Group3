namespace Backend.Models
{
    public class UtilityCost
    {
        public int PreviousMetric {  get; set; }
        public int NewMetric { get; set; }
        public Guid BillId { get; set; }
        public int UtilityCostTypeId {  get; set; }
        public UtilityCostType UtilityCostType { get; set; }
        public Bill Bill { get; set; }
    }
}
