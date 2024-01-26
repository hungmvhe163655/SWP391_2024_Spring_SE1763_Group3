namespace Backend.Models
{
    public class UtilityCostType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }  
        public ICollection<UtilityCost> UtilityCosts { get; set; }
    }
}
