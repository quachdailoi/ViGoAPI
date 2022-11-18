using Domain.Entities;

namespace API.Services.Constract
{
    public interface IUserLicenseService
    {
        IQueryable<UserLicense> GetLicenseByCodeAndType(string code, LicenseTypes type);
        IQueryable<UserLicense> GetLicenseByUserIdAndType(int userId, LicenseTypes type);
    }
}
