using Entities.Exceptions.BaseClass;

namespace Entities.Exceptions
{
    public sealed class DateRangeBadRequestException : BadRequestException
    {
        public DateRangeBadRequestException() :
            base("Start Date cannot be bigger than End Date")
        {
        }
    }
}
