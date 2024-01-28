namespace Backend.Models
{
    public class UtilityCost
    {
        public int PreviousMetric {  get; set; }
        public int NewMetric { get; set; }
        public UtilityCostType Type { get; set; }     
    }
}
