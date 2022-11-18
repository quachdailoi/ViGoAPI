using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserLicense : BaseEntity
    {
        public string Code { get; set; }
        public int UserId { get; set; }
        public int FrontSideFileId { get; set; }
        public int BackSideFileId { get; set; }
        public LicenseTypes LicenseTypeId { get; set; }

        public User User { get; set; }
        public AppFile FrontSideFile { get; set; }
        public AppFile BackSideFile { get; set; }
        public LicenseType LicenseType { get; set; }
    }
}
