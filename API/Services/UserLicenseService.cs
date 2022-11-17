using API.Services.Constract;
using Domain.Entities;

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
    }
}
