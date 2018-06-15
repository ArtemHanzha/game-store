using System;
using System.Collections.Generic;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class BookViewModel
    {
        public DateTime PublicationDate { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
        public ICollection<string> Authors { get; set; }
        public string PublicationHouse { get; set; }
        public ICollection<string> Tags { get; set; }
        public string Description { get; set; }
    }
}