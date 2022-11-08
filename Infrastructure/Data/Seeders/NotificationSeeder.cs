using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class NotificationSeeder
    {
        public NotificationSeeder(ModelBuilder builder)
        {
            var notifications = new List<Notification>()
            {
            };

            for(var i = 0; i < 10; i++)
            {
                notifications.Add(new Notification()
                {
                    Id = i + 1,
                    Code = Guid.NewGuid(),
                    EventId = (Events.Types)new Random().Next(1, (int)Events.Types.Completed + 1),
                    Status = Notifications.Status.Active,
                    Type = Notifications.Types.Booker,
                    UserId = 7
                });
            }

            builder.Entity<Notification>().HasData(notifications);
        }
    }
}
