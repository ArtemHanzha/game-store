namespace EmapLibrary.UserInterface.ViewModels
{
    public class CommentViewModel
    {
        public string ReviewerFullName { get; set; }
        
        public int ReviewerId { get; set; }

        public int BookId { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }
    }
}