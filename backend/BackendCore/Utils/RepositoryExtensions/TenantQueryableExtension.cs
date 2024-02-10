using BackendCore.Utils.RequestFeatures;
using Entities.Models;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace BackendCore.Utils.RepositoryExtensions
{
    public static class TenantQueryableExtension
    {
        public static IQueryable<Tenant> FilterGender(this IQueryable<Tenant> tenants,
            bool? isMale)
        {
            return tenants.Where(t => t.IsMale == isMale);
        }
        public static IQueryable<Tenant> FilterCreatedDate(this IQueryable<Tenant> tenants,
            DateTime? startCreatedDate, DateTime? endCreatedDate)
        {
            return tenants.Where(t => t.CreatedAt >= startCreatedDate
                    && t.CreatedAt <= endCreatedDate);
        }

        public static IQueryable<Tenant> Search(this IQueryable<Tenant> tenants,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return tenants;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return tenants.Where(e => e.FullName.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Tenant> Sort(this IQueryable<Tenant> tenants,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return tenants.OrderBy(e => e.FullName);

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Tenant>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return tenants.OrderBy(e => e.FullName);

            return tenants.OrderBy(orderQuery);
        }
    }
}
