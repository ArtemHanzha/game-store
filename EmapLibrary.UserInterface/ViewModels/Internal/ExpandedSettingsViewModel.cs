using System.Text.RegularExpressions;
using EpamLibrary.Contracts.Enums;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class ExpandedSettingsViewModel : UserSettingsViewModel
    {
        public int UserId { get; set; }

        public string WorkerNumber { get; set; }

        public string LibraryNumber { get; set; }

        public bool IsBlocked { get; set; }

        public UserType UserType { get; set; }

        public override UserViewModel User
        {
            set
            {
                base.User = value;
                WorkerNumber = value.WorkerNumber;
                LibraryNumber = value.LibraryNumber;
                IsBlocked = value.IsBlocked;
                UserType = value.UserType;
            }
        }

        public bool IsWorkerNumberError { get; set; }
        public bool IsLibraryNumberError { get; set; }


        public override bool HaveError()
        {
            var @base = base.HaveError();

            var digitReg = new Regex(@"^\d+$");

            if(WorkerNumber != null)
                IsWorkerNumberError |= !digitReg.IsMatch(WorkerNumber);
            IsLibraryNumberError |= !digitReg.IsMatch(LibraryNumber);

            return IsLibraryNumberError || IsWorkerNumberError || @base;
        }

        public override bool IsFirstIn
        {
            get
            {
                var @base = base.IsFirstIn;
                if (string.IsNullOrWhiteSpace(WorkerNumber) && string.IsNullOrWhiteSpace(LibraryNumber) && @base)
                {
                    IsWorkerNumberError = false;
                    IsLibraryNumberError = false;
                    return true;
                }
                return false;
            }
        }
    }
}