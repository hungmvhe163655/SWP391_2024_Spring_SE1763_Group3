/**
 * Class for Role, this is use for entity framework to generate database.
 * This class is represent for a table in database.
 * 
 * One Role has many Building Residents.
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Many Building Residents
        public ICollection<BuildingResident> BuildingResidents { get; set; }
    }
}
