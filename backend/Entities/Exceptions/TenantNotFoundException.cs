using Entities.Exceptions.BaseClass;

namespace Entities.Exceptions
{
    public sealed class TenantNotFoundException : NotFoundException
    {
        public TenantNotFoundException(string newsId) :
            base($"The Tenant with id: {newsId} doesn't exist in the database.")
        {
        }
    }
}
