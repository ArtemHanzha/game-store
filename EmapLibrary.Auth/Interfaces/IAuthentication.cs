using System.Security.Principal;
using System.Web;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.Auth.Interfaces
{
    public interface IAuthentication
    {
        User User { get; }

        IPrincipal CurrentUser { get; }

        HttpContext Context { get; set; }

        User Login(string login, string password, bool stayLogged);

        void Logout();
    }
}