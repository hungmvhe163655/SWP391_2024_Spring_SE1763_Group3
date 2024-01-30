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
    [Route("api/[controller]")]
    [ApiController]
    public class BillStatusController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;

        public BillStatusController(HomeManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/BillStatus
        [HttpGet]
        public ActionResult<List<BillStatus>> Get()
        {
            return Ok(_context.BillStatuses.ToList());
        }
        [HttpPost]
        public ActionResult Post(CreateBillStatusDTO billStatusDTO)
        {
            try
            {
                BillStatus billStatus = new()
                {
                    Status = billStatusDTO.Status
                };
                _context.BillStatuses.Add(billStatus);
                _context.SaveChanges();
                return Ok("Save successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
