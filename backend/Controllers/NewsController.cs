using Backend.DTOs;
using Backend.DTOs.NewsDTO;
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
    public class NewsController : ControllerBase
    {
        private readonly HomeManagementDbContext _context;

        public NewsController(HomeManagementDbContext context)
        {
            _context = context;
        }

        // GET api/role
        [HttpGet]
        public ActionResult<List<News>> Get()
        {
            // Retrieve and return a list of all roles from the database
            return Ok(_context.Roles.ToList());
        }
        [HttpPost]
        public ActionResult Create([FromBody] CreateNewsDTO newsCreate)
        {
            try
            {
                // Create a new News entity based on the provided DTO
                News news = new News
                {                  
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Title = newsCreate.Title,
                    Description = newsCreate.Description,    
                };

                // Add the new news to the database and save changes
                _context.News.Add(news);
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
        public ActionResult Delete(Guid id)
        {
            try
            {
                // Find the news with the specified ID
                var newsToDelete = _context.News.FirstOrDefault(x => x.Id == id);

                // Return a not found response if the news is not found
                if (newsToDelete == null)
                {
                    return NotFound("News not found.");
                }

                // Remove the news from the database and save changes
                _context.News.Remove(newsToDelete);
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
        public ActionResult Update(Guid id, DTOs.NewsDTO.UpdateNewsDTO newsUpdate)
        {
            try
            {
                var existingNews = _context.News.FirstOrDefault(x => x.Id == id);

                if (existingNews == null)
                {
                    return NotFound("News not found.");
                }

                // Update the properties of the existing news based on the provided DTO
                existingNews.Title = newsUpdate.Title;
                existingNews.Description = newsUpdate.Description;

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