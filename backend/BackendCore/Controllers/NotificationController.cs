using AutoMapper;
using BackendCore.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendCore.Controllers
{
    [Route("api/tenants/{tenantId}/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public NotificationController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
