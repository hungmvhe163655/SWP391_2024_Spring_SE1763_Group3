﻿/**
 * Class for Apartment, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * One apartment have many rooms.
 * One apartment have many managers.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public Guid HomeManagerId { get; set; }
        public HomeManager HomeManager { get; set; }
        //Many relationship 
        public ICollection<Room> Rooms { get; set; }
        public ICollection<BuildingService> BuildingServices { get; set; }
        public ICollection<News> News { get; set; }
    }
}
