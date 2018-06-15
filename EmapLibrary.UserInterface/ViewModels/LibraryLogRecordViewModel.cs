using System;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class LibraryLogRecordViewModel
    {
        public int BookInstacneNumber { get; set; }

        public string BookInstanceNameTitle { get; set; }

        public ConsumerViewModel Consumer { get; set; }

        public WorkerViewModel Worker { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime ExpectedReturnTime { get; set; }

        public DateTime RealReturnTime { get; set; }
    }
}