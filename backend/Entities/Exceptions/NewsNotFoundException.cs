using Entities.Exceptions.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class NewsNotFoundException : NotFoundException
    {
        public NewsNotFoundException(String newsId) :
            base($"The News with id: {newsId} doesn't exist in the database.")
        {
        }
    }
}
