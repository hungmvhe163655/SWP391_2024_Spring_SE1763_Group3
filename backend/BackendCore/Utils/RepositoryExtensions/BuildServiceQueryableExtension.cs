using BackendCore.Utils.RequestFeatures;
using Entities.Models;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace BackendCore.Utils.RepositoryExtensions
{
    public static class BuildingServiceQueryableExtension
    {
        public static IQueryable<BuildingService> Search(this IQueryable<BuildingService> buildServices,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return buildServices;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return buildServices.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<BuildingService> Sort(this IQueryable<BuildingService> buildServices,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return buildServices.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<BuildingService>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return buildServices.OrderBy(e => e.Name);

            return buildServices.OrderBy(orderQuery);
        }
    }
}
