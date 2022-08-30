using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Shares.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class VerifiedCodeRepository : GenericRepository<VerifiedCode>, IVerifiedCodeRepository
    {
        public VerifiedCodeRepository(AppDbContext dbContext, ILogger<GenericRepository<VerifiedCode>> logger) : base(dbContext, logger)
        {
        }

        public async Task<VerifiedCode> CreateVerifiedCode(VerifiedCode verifiedCode)
        {
            return await Add(verifiedCode);
        }

        public async Task DisableCode(VerifiedCode verifiedCode)
        {
            verifiedCode.Status = false;
            await Update(verifiedCode);
        }

        public IQueryable<VerifiedCode> GetVerifiedCode(string registration, RegistrationTypes registrationType, OtpTypes codeType)
        {
            return List(x => x.Registration == registration && 
                                x.RegistrationType == registrationType &&
                                x.Type == codeType).OrderByDescending(x => x.CreatedAt);
        }

        public IQueryable<VerifiedCode> GetVerifiedCode(string otp, string registration, RegistrationTypes registrationType, OtpTypes codeType)
        {
            return GetVerifiedCode(registration, registrationType, codeType).Where(x => x.Code == otp && x.Status);
        }
    }
}
