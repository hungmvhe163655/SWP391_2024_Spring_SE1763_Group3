namespace Backend.Models
{
    public class BuildingResident
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string PortraitPictureUrl { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
