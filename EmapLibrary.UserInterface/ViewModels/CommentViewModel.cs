namespace EmapLibrary.UserInterface.ViewModels
{
    public class CommentViewModel
    {
        public UserViewModel Reviewer { get; set; }

        public BookViewModel Book { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }
    }
}