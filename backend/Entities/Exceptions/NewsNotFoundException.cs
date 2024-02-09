namespace Entities.Exceptions
{
    public sealed class TenantNotFoundException : NotFoundException
    {
        public TenantNotFoundException(Guid newsId) :
            base($"The Tenant with id: {newsId} doesn't exist in the database.")
        {
        }
    }
}
