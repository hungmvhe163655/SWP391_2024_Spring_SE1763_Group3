namespace Entities.Exceptions
{
    public sealed class NewsNotFoundException : NotFoundException
    {
        public NewsNotFoundException(Guid newsId) :
            base($"The company with id: {newsId} doesn't exist in the database.")
        {
        }
    }
}
