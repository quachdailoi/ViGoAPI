using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Genders Gender { get; set; } = 0;
        public StatusTypes.User Status { get; set; } = StatusTypes.User.Active;
        public DateTimeOffset? DateOfBirth { get; set; } = null;
        public int? FileId { get; set; }

        public List<Account> Accounts { get; set; } = new();
        public List<UserRoom> UserRooms { get; set; } = new();

        public List<Message> Messages { get; set; } = new();
        public List<Booking> Bookings { get; set; } = new();

        public AppFile? File { get; set; }
        public List<PromotionUser> PromotionUsers { get; set; } = null!;
        public List<RouteRoutine> RouteRoutines { get; set; } = null!;
        public List<BookingDetailDriver> BookingDetailDrivers { get; set; } = new();
        public Vehicle? Vehicle { get; set; } = null;
        public Wallet? Wallet { get; set; } = null;

        // virtual property - be careful - must have auto include before use these.
        public string? FilePath => File?.Path;
        public Guid? FileCode => File?.Code;
        public string? Gmail => GetAccount(Accounts, RegistrationTypes.Gmail)?.Registration;
        public bool? IsVerifiedGmail => GetAccount(Accounts, RegistrationTypes.Gmail)?.Verified;
        public string? PhoneNumber => GetAccount(Accounts, RegistrationTypes.Phone)?.Registration;
        public bool? IsVerifiedPhoneNumber => GetAccount(Accounts, RegistrationTypes.Phone)?.Verified;
        public string? RoleName => Accounts.FirstOrDefault()?.Role?.Name;

        private Account? GetAccount(List<Account> accounts, RegistrationTypes type)
            => accounts.Where(acc => acc.RegistrationType == type).FirstOrDefault();
    }
}
