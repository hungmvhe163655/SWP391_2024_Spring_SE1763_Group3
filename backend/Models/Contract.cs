﻿/**
 * Class for Contract, this is use for entity framework to generate database.
 * This class is represent for a table in database. 
 * 
 * <p>ExpectedCheckOutDate is fix checkout date in contract, 
 * if tenant checkout before this, tenant will loose deposit</p>
 * 
 * @author HungMV
 */

#nullable disable
namespace Backend.Models
{
    public class Contract
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime ExpectedCheckOutDate { get; set; }
        public DateTime? RealCheckOutDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Deposit { get; set; }
        public Room Room { get; set; }
        public Tenant Tenant { get; set; }
    }
}
