namespace Shared.HomeManagerDTO
{
    public class UpdateHomeManagerDTO
    {
        public Guid Id { get; set; }
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
    }
}
