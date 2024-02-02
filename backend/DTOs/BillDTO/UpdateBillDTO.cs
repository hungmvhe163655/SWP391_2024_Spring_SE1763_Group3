namespace Backend.DTOs.BillDTO
{
    public class UpdateBillDTO
    {
        public Guid Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int BillStatusId { get; set; }

        // One Room 
        public Guid RoomId { get; set; }
    }
}
