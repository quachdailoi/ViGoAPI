using API.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper.CustomResolver
{
    public class EmailResolver : IValueResolver<User, UserViewModel, string>
    {
        public string Resolve(User source, UserViewModel destination, string destMember, ResolutionContext context)
        {
            var accounts = source.Accounts;

            foreach (var acc in accounts)
            {
                if (acc.RegistrationType == ((int)RegistrationTypes.Email))
                {
                    return acc.Registration;
                } 
            }

            return null;
        }
    }
}
