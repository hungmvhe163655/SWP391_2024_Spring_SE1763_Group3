namespace Backend.DTOs.BuildingDTO
{
    public class CreateBuildingDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid HomeManagerId { get; set; }
    }
}
