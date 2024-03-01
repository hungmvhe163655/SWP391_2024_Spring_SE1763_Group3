namespace Backend.DTOs.BuildingDTO
{
    public class UpdateBuildingDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
