using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LicenseType
    {
        public LicenseTypes Id { get; set; }
        public string Name { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();

        public List<UserLicense> UserLicenses { get; set; }
    }

    public enum LicenseTypes
    {
        Identification = 1,
        DriverLicense = 2,
        VehicleRegistration = 3,
    }
}
