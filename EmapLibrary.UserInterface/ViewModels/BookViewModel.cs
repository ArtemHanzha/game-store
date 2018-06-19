using System;
using System.Collections.Generic;
using EmapLibrary.UserInterface.ViewModels.Abstract;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
        public ICollection<string> Authors { get; set; }
        public ICollection<string> Genres { get; set; }
        public string PublicationHouse { get; set; }
        public ICollection<string> Tags { get; set; }
        public string Description { get; set; }
        public int InstancesCount { get; set; }
    }
}