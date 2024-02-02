using Backend.DTOs;
using Backend.DTOs.BuildingDTO;
using Backend.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;

        public BuildingController(HomeManagementDbContext context)
        {
            _context = context;
        }

        // GET api/building
        [HttpGet]
        public ActionResult<List<Building>> Get()
        {
            // Retrieve and return a list of all buildings from the database
            return Ok(_context.Buildings.ToList());
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateBuildingDTO buildingCreate)
        {
            try
            {
                // Create a new Building entity based on the provided DTO
                Building building = new Building
                {
                    CreatedAt = DateTime.UtcNow,
                    Name = buildingCreate.Name,
                    Address = buildingCreate.Address,
                    Description = buildingCreate.Description,
                    // You may need to handle the relationship with HomeManager separately
                };
                // Add the new building to the database and save changes
                _context.Buildings.Add(building);
                _context.SaveChanges();

                // Return a success message
                return Ok("Create Successfully!");
            }
            catch (Exception ex)
            {
                // Log the exception or inspect it for debugging
                Console.WriteLine($"Error: {ex.Message}");

                // If there is an inner exception, log it as well
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                // Return a bad request response with the exception message if an error occurs
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                // Find the building with the specified ID
                var buildingToDelete = _context.Buildings.FirstOrDefault(x => x.Id == id);

                // Return a not found response if the building is not found
                if (buildingToDelete == null)
                {
                    return NotFound("Building not found.");
                }

                // Remove the building from the database and save changes
                _context.Buildings.Remove(buildingToDelete);
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

        [HttpPut("{id}")]
        public ActionResult Update(int id, UpdateBuildingDTO buildingUpdate)
        {
            try
            {
                var existingBuilding = _context.Buildings.FirstOrDefault(x => x.Id == id);

                if (existingBuilding == null)
                {
                    return NotFound("Building not found.");
                }

                // Update the properties of the existing building based on the provided DTO
                existingBuilding.Name = buildingUpdate.Name;
                existingBuilding.Address = buildingUpdate.Address;
                existingBuilding.Description = buildingUpdate.Description;

                // You may need to handle the relationship with HomeManager separately
                existingBuilding.HomeManagerId = buildingUpdate.HomeManagerId;

                _context.SaveChanges();

                return Ok("Update Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
