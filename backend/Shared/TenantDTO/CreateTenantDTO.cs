namespace Shared.TenantDTO
{
    public class CreateTenantDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Picture will be save on GG drive instead
        public string PortraitPictureUrl { get; set; }

        // One Role
        public int RoleId { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public Guid RoomId { get; set; }
    }
}
