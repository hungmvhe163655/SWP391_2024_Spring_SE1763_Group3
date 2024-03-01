using Entities.Models;

namespace BackendCore.Utils.RepositoryExtensions
{
    public static class NewsQueryableExtension
    {
        public static IQueryable<News> FilterCreatedDate(this IQueryable<News> news,
            DateTime? startCreatedDate, DateTime? endCreatedDate)
        {
            return news.Where(n => n.CreatedAt >= startCreatedDate
                    && n.CreatedAt <= endCreatedDate);
        }
    }
}
