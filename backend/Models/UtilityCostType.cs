namespace Backend.Models
{
    public class UtilityCostType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }  
        public bool IsDeleted { get; set; }
        public decimal PricePerUnit { get; set; }
        public ICollection<UtilityCost> UtilityCosts { get; set; }
    }
}
