namespace Shared.TenantDTO
{
    public record CreateTenantDTO : TenantBaseDTO
    {
        public DateTime CreatedAt { get; set; }
    }
}
