using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class BuildingServiceNotFoundException : Exception
    {
        public BuildingServiceNotFoundException(Guid newsId) :
            base($"The Building Service with id: {newsId} doesn't exist in the database.")
        {
        }
    }
}
