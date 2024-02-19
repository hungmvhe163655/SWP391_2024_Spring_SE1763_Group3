using Entities.Exceptions.BaseClass;

namespace Entities.Exceptions
{
    public sealed class ContractNotFoundException : NotFoundException
    {
        public ContractNotFoundException(Guid newsId) :
            base($"The Contract with id: {newsId} doesn't exist in the database.")
        {
        }
    }
}
