using Domain.Entities;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IVerifiedCodeRepository : IGenericRepository<VerifiedCode>
    {
        Task DisableCode(VerifiedCode verifiedCode);
        Task<VerifiedCode> CreateVerifiedCode(VerifiedCode verifiedCode);

        IQueryable<VerifiedCode> GetVerifiedCode(string registration, RegistrationTypes registrationType, OtpTypes codeType);

        IQueryable<VerifiedCode> GetVerifiedCode(string otp, string registration, RegistrationTypes registrationType, OtpTypes codeType);
    }
}
