using API.Services.Constract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserLicenseService : BaseService, IUserLicenseService
    {
        public UserLicenseService(IAppServices appServices) : base(appServices)
        {
        }

        public IQueryable<UserLicense> GetLicenseByCodeAndType(string code, LicenseTypes type)
        {
            return UnitOfWork.UserLicenses.List(x => x.Code == code && x.LicenseTypeId == type);
        }

        public IQueryable<UserLicense> GetLicenseByUserIdAndType(int userId, LicenseTypes type)
        {
            return UnitOfWork.UserLicenses.List(x => x.UserId == userId && x.LicenseTypeId == type)
                .Include(x => x.FrontSideFile)
                .Include(x => x.BackSideFile);
        }
    }
}
