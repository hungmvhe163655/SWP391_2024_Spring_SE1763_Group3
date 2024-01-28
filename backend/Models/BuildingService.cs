using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class BuildingService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Money { get; set; }   
        public ICollection<Building> Buildings { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
