using Backend.DTOs;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;

        public RoleController(HomeManagementDbContext context)
        {
            _context = context;
        }

        // GET api/role
        [HttpGet]
        public ActionResult<List<Role>> Get()
        {
            // Retrieve and return a list of all roles from the database
            return Ok(_context.Roles.ToList());
        }

        // POST api/role
        [HttpPost]
        public ActionResult Post(DTOs.RoleDTO.CreateRoleDTO rolePost)
        {
            try
            {
                // Create a new Role entity based on the provided DTO
                Role role = new Role
                {
                    Name = rolePost.Name
                };

                // Add the new role to the database and save changes
                _context.Roles.Add(role);
                _context.SaveChanges();

                // Return a success message
                return Ok("Save Successfully!");
            }
            catch (Exception ex)
            {
                // Return a bad request response with the exception message if an error occurs
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/role/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                // Find the role with the specified ID
                var roleToDelete = _context.Roles.FirstOrDefault(x => x.Id == id);

                // Return a not found response if the role is not found
                if (roleToDelete == null)
                {
                    return NotFound("Role not found.");
                }

                // Remove the role from the database and save changes
                _context.Roles.Remove(roleToDelete);
                _context.SaveChanges();

                // Return a success message
                return Ok("Delete Successfully!");
            }
            catch (Exception ex)
            {
                // Return a bad request response with the exception message if an error occurs
                return BadRequest(ex.Message);
            }
        }

        // PUT api/role/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, DTOs.RoleDTO.UpdateRoleDTO roleUpdate)
        {
            try
            {
                // Find the existing role with the specified ID
                var existingRole = _context.Roles.FirstOrDefault(x => x.Id == id);

                // Return a not found response if the existing role is not found
                if (existingRole == null)
                {
                    return NotFound("Role not found.");
                }

                // Update the properties of the existing role based on the provided DTO
                existingRole.Name = roleUpdate.Name;

                // Save changes to the database
                _context.SaveChanges();

                // Return a success message
                return Ok("Update Successfully!");
            }
            catch (Exception ex)
            {
                // Return a bad request response with the exception message if an error occurs
                return BadRequest(ex.Message);
            }
        }
    }
}

