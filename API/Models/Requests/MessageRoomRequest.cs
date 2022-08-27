namespace API.Models.Requests
{
    public class MessageRoomRequest
    {
        public List<Guid> PartnerUserCodes { get; set; } = new();
    }
}
