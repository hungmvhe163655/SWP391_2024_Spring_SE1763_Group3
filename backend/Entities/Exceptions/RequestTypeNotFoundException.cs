using Entities.Exceptions.BaseClass;

namespace Entities.Exceptions
{
    public sealed class RequestTypeNotFoundException : NotFoundException
    {
        public RequestTypeNotFoundException(int newsId) :
            base($"The Request Type with id: {newsId} doesn't exist in the database.")
        {
        }
    }
}
