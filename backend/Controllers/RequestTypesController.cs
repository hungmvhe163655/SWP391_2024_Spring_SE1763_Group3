using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Utils;
using Backend.DTOs;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestTypesController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;

        public RequestTypesController(HomeManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/RequestTypes
        [HttpGet]
        public ActionResult<IEnumerable<RequestType>> GetRequestTypes()
        {
            return _context.RequestTypes.ToList();
        }

        // GET: api/RequestTypes/5
        [HttpGet("{id}")]
        public ActionResult<RequestType> GetRequestType(int id)
        {
            var requestType = _context.RequestTypes.Find(id);

            if (requestType == null)
            {
                return NotFound();
            }

            return requestType;
        }

        // POST: api/RequestTypes
        [HttpPost]
        public ActionResult<RequestType> PostRequestType(CreateRequestTypeDTO requestTypeDto)
        {
            var requestType = new RequestType { Type = requestTypeDto.Type };
            _context.RequestTypes.Add(requestType);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRequestType), new { id = requestType.Id }, requestType);
        }

        // DELETE: api/RequestTypes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRequestType(int id)
        {
            var requestType = _context.RequestTypes.Find(id);
            if (requestType == null)
            {
                return NotFound();
            }

            _context.RequestTypes.Remove(requestType);
            _context.SaveChanges();

            return NoContent();
        }
    }
}