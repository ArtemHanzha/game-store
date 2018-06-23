using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class BookChangeViewModel
    {
        public BookChangeViewModel()
        {
        }

        public BookChangeViewModel(BookViewModel book)
        {
            Id = book.Id;
            Title = book.Title;
            PublicationDate = book.PublicationDate.ToShortDateString();
            PubHouse = book.PublicationHouse;
            Tags = ArrayToString(book.Tags);
            Genres = ArrayToString(book.Genres);
            Authors = ArrayToString(book.Authors);
            Description = book.Description;
            InstancesCount = book.InstancesCount.ToString();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string PublicationDate { get; set; }
        public string PubHouse { get; set; }
        public string Tags { get; set; }
        public string Genres { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public string InstancesCount { get; set; }

        public bool IsTitleError { get; set; }
        public bool IsPubHouseError { get; set; }
        public bool IsPubDateError { get; set; }
        public bool IsTagsError { get; set; }
        public bool IsGenresError { get; set; }
        public bool IsAuthorsError { get; set; }
        public bool IsDescriptionError { get; set; }
        public bool IsBookCountError { get; set; }

        public bool HaveError()
        {
            var enumRegex = new Regex(@"^(\w+,)*$");
            var authorsRegex = new Regex(@"^(\w+ \w+ \w+,)+$");
            var dateRegex = new Regex(@"^\d{2}/\d{2}/\d{2}(\d{2})?$");
            var intRegex = new Regex(@"^\d+$");


            IsTitleError |= string.IsNullOrWhiteSpace(Title);
            IsPubHouseError |= string.IsNullOrWhiteSpace(PubHouse);
            IsPubDateError |= !dateRegex.IsMatch(PublicationDate);
            IsTagsError |= !enumRegex.IsMatch(Tags);
            IsGenresError |=! enumRegex.IsMatch(Genres);
            IsAuthorsError |= !authorsRegex.IsMatch(Authors);
            IsDescriptionError |= string.IsNullOrWhiteSpace(Description);
            IsBookCountError |= !intRegex.IsMatch(InstancesCount);

            return (IsTitleError || IsPubHouseError || IsPubDateError || IsTagsError || IsGenresError || IsAuthorsError || IsDescriptionError || IsBookCountError);
        }

        public bool FirstStart()
        {
            bool itWas = string.IsNullOrWhiteSpace(Title) &&
                       string.IsNullOrWhiteSpace(PublicationDate) &&
                       string.IsNullOrWhiteSpace(PubHouse) &&
                       string.IsNullOrWhiteSpace(Tags) &&
                       string.IsNullOrWhiteSpace(Genres) &&
                       string.IsNullOrWhiteSpace(Authors) &&
                       string.IsNullOrWhiteSpace(Description) &&
                       string.IsNullOrWhiteSpace(InstancesCount);

            return itWas;
        }

        string ArrayToString(IEnumerable<string> array)
        {
            var str = "";
            foreach (var element in array)
            {
                str += element;
            }

            return str;
        }
    }
}