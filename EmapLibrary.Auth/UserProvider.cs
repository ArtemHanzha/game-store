using System;
using System.Linq;
using System.Security.Principal;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models;
using EpamLibrary.DAL.Interfaces;

namespace EmapLibrary.Auth
{
    internal class UserProvider : IPrincipal
    {
        private UserIdentity UserIdentity { get; }

        public IIdentity Identity => UserIdentity;

        public UserProvider()
        {
            UserIdentity = new UserIdentity();
        }

        public UserProvider(string name, IRepository<User> userRepository)
        {
            UserIdentity = new UserIdentity(name, userRepository);
        }

        public bool IsInRole(string role)
        {
            if (UserIdentity.User == null || string.IsNullOrWhiteSpace(role))
                return false;

            var roles = role.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var enums = Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList();
            // return roles.Any(r =>
            //     string.Compare(r, nameof(UserIdentity.User.UserType), StringComparison.OrdinalIgnoreCase) == 0);
            //return roles.Any(r => enums.Any(e => e.ToString() == r));
            return roles.Any(r => r == UserIdentity.User.UserType.ToString());
        }
    }
}