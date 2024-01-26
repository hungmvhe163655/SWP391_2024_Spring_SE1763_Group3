namespace Backend.Models
{
    public class RoomService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public ICollection<Room> Rooms { get; set; }
        
    }
}
