using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class GetMessageRoomRequest
    {
        public Rooms.RoomTypes? Type { get; set; } = null;
        public Guid? Code { get; set; } = null;
    }
}
