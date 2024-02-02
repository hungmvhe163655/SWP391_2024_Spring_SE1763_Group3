using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Utils;
using AutoMapper;
using Backend.DTOs;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillStatusController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;
        private readonly IMapper _mapper;

        public BillStatusController(HomeManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BillStatus
        [HttpGet]
        public ActionResult<List<BillStatus>> Get()
        {
            return Ok(_context.BillStatuses.ToList());
        }

        // GET: api/BillStatus
        [HttpGet("{id}")]
        public ActionResult<BillStatus> Get(int id)
        {
            BillStatus? billStatus = _context.BillStatuses.FirstOrDefault(b => b.Id == id);
            if (billStatus == null)
            {
                return NotFound("Bill Status Not Found");
            }
            return Ok(billStatus);
        }

        // POST: api/BillStatus
        [HttpPost]
        public ActionResult Post(CreateBillStatusDTO billStatusDTO)
        {
            try
            {
                BillStatus billStatus = _mapper.Map<BillStatus>(billStatusDTO);
                _context.BillStatuses.Add(billStatus);
                _context.SaveChanges();
                return Ok("Save successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult Update(BillStatus billStatus)
        {
            try { }
        }
        //PUT: api/BillStatus/id
        [HttpPut("{id}")]

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleteBillStatus = _context.BillStatuses.FirstOrDefault(b => b.Id == id);
            if (deleteBillStatus == null)
            {
                return NotFound();
            }

            _context.BillStatuses.Remove(deleteBillStatus);
            _context.SaveChanges();
            return Ok("Deleted successfully!");
        }
    }
}
