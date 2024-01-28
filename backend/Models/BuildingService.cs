namespace Backend.Models
{
    public class BuildingService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }   
        public ICollection<Building> Buildings { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
