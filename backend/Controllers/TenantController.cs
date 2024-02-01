using AutoMapper;
using Backend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        // Inject service
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;
    }
}
