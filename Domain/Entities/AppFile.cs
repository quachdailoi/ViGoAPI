using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppFile : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public string Path { get; set; } = string.Empty;
        public FileTypes Type { get; set; } = FileTypes.AvatarImage;
        public bool Status { get; set; } = true;

        public User User { get; set; }
        public Promotion Promotion { get; set; }
        public Banner Banner { get; set; }
        public virtual List<UserLicense> FrontSideUserLicenses { get; set; } = new();
        public virtual List<UserLicense> BackSideUserLicenses { get; set; } = new();
    }
}
