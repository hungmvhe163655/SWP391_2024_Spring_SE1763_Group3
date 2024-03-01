using AutoMapper;
using BackendCore.Utils;
using BackendCore.Utils.ActionFilters;
using BackendCore.Utils.RepositoryExtensions;
using BackendCore.Utils.RequestFeatures.EntityParameters;
using BackendCore.Utils.RequestFeatures.Paging;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.NewsDTO;
using Shared.NotificationDTO;
using Shared.RequestDTO;
using Shared.TenantDTO;
using System.Text.Json;

namespace BackendCore.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public NewsController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetNews(
            [FromQuery] NewsParameter newsParameters)
        {

            var queryNews = BuildQuery(_context.News.AsNoTracking(),
                newsParameters);

            var pagedNews = await PagedList<News>.ToPagedListAsync(queryNews,
                newsParameters.PageNumber, newsParameters.PageSize);

            var newsDTO = _mapper.Map<IEnumerable<ReadNewsDTO>>(pagedNews);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedNews.MetaData));

            return Ok(newsDTO);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateNews(
            [FromBody] CreateNewsDTO createNewsDTO)
        {
            var createNews = _mapper.Map<News>(createNewsDTO);

            await _context.News.AddAsync(createNews);
            await _context.SaveChangesAsync();

            var createdTenant = _mapper.Map<ReadNewsDTO>(createNews);

            return CreatedAtRoute("NewsById", new { id = createNews.Id }, createNews);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateNews(string id,
            [FromBody] UpdateNewsDTO updateNewsDTO)
        {
            var news = await FindNews(id);

            _mapper.Map(updateNewsDTO, news);
            await _context.SaveChangesAsync();

            return Ok("Update successful!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(string id)
        {
            var deleteNews = await FindNews(id);

            _context.News.Remove(deleteNews);
            await _context.SaveChangesAsync();

            return Ok("Delete successful!");
        }

        private async Task<News> FindNews(string id)
            => await _context.News.FindAsync(id)
             ?? throw new NewsNotFoundException(id);

        private IQueryable<News> BuildQuery(IQueryable<News> query,
            NewsParameter parameters)
        {

            // Filter Created Date
            if (parameters.StartCreatedDate != null && parameters.EndCreatedDate != null)
            {
                if (!parameters.ValidDateRange)
                {
                    throw new DateRangeBadRequestException();
                }

                query = query.FilterCreatedDate(parameters.StartCreatedDate,
                    parameters.EndCreatedDate);
            }

            return query;
        }
    }
}
