namespace Backend.Models
{
    public class BillStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
