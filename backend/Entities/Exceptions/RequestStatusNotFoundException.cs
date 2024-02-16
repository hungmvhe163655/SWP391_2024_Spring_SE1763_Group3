﻿using Entities.Exceptions.BaseClass;

namespace Entities.Exceptions
{
    public sealed class RequestStatusNotFoundException : NotFoundException
    {
        public RequestStatusNotFoundException(Guid newsId) :
            base($"The Request Status with id: {newsId} doesn't exist in the database.")
        {
        }
    }
}
