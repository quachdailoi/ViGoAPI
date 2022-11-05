using Domain.Shares.Enums;

namespace API.Models.DTO
{
    public class MappingItemDTO
    {
        public int Id { get; set; }
        public TaskItems.MappingItemTypes Type { get; set; } = TaskItems.MappingItemTypes.Booking;
    }
}
