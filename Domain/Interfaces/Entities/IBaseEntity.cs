namespace Domain.Interfaces.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        int CreatedBy { get; set; }
        DateTimeOffset UpdatedAt { get; set; }
        int UpdatedBy { get; set; }

        DateTimeOffset? DeletedAt { get; set; }
    }
}
