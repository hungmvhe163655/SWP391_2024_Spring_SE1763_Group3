namespace Entities.Exceptions.BaseClass
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message)
        : base(message)
        {
        }
    }
}
