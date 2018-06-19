using EpamLibrary.Contracts.Enums;

namespace EmapLibrary.UserInterface.ViewModels.Abstract
{
    public abstract class BaseViewModel
    {
        public bool IsLogged { get; set; }

        public bool IsBanned { get; set; }

        public UserType UserType { get; set; }
    }
}