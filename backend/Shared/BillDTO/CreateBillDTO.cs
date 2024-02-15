namespace Shared.BillDTO
{
    public class CreateBillDTO
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int BillStatusId { get; set; }

        // One Room 
        public Guid RoomId { get; set; }

    }
}
