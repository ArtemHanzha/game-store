using System.Linq;
using System.Security.Principal;
using EpamLibrary.Contracts.Models;
using EpamLibrary.DAL.Interfaces;

namespace EmapLibrary.Auth
{
    public class UserIdentity : IIdentity
    {
        public User User { get; set; }

        public string Name => User == null ? "N/A" : $"{User.Name} {User.Surname}";
        public string AuthenticationType => "Custom";
        public bool IsAuthenticated => User != null;

        /// <summary>
        /// For empty User
        /// </summary>
        public UserIdentity()
        {

        }

        /// <summary>
        /// Try to authorize
        /// </summary>
        /// <param name="login"></param>
        /// <param name="userRepository"></param>
        public UserIdentity(string login, IRepository<User> userRepository)
        {
            if (string.IsNullOrEmpty(login))
                return;
            User = userRepository.Get(u => u.Login == login).First();
        }
    }
}
