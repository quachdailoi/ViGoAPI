using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper.CustomResolver
{
    public class RoleNameResolver : IValueResolver<User, UserViewModel, string>
    {
        public string Resolve(User source, UserViewModel destination, string destMember, ResolutionContext context)
        {
            var accounts = source.Accounts;

            var roleName = accounts.First().Role.Name;

            return roleName;
        }
    }
}
