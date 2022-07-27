﻿namespace Domain.Interfaces.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        int CreatedBy { get; set; } 
        DateTime UpdatedAt { get; set; }
        int UpdatedBy { get; set; } 

        DateTime? DeletedAt { get; set; }
    }
}
