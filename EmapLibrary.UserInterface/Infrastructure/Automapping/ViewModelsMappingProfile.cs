using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmapLibrary.UserInterface.ViewModels;
using EmapLibrary.UserInterface.ViewModels.Internal;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.Infrastructure.Automapping
{
    public class ViewModelsMappingProfile : Profile
    {
        public ViewModelsMappingProfile()
        {
            #region Comment -> commentVM
            CreateMap<Comment, CommentViewModel>()
                .ForMember(c => c.Book, opt => opt.MapFrom(s => Mapper.Map<Book, BookViewModel>(s.Book)))
                .ForMember(c => c.Rating, opt => opt.MapFrom(s => (int)s.Rating))
                .ForMember(c => c.Review, opt => opt.MapFrom(s => s.Review))
                .ForMember(c => c.Reviewer, opt => opt.MapFrom(s => Mapper.Map<User, UserViewModel>(s.Reviewer)));
            #endregion

            #region Book -> bookVm
            CreateMap<Book, BookViewModel>()
                .ForMember(c => c.InstancesCount, opt => opt.MapFrom(s => s.ConcreteBooks.Count))
                .ForMember(c=> c.Id, opt => opt.MapFrom(s=>s.Id))
                .ForMember(c=>  c.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(c => c.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(c => c.PublicationHouse, opt => opt.MapFrom(s => s.PublicationHouse))
                .ForMember(c => c.PublicationDate, opt => opt.MapFrom(sel => sel.DateOfPublication))
                .ForMember(c => c.Tags, opt => opt.MapFrom(s => s.Tags.Select(sel => sel.TagName).ToList()))
                .ForMember(c=>  c.Genres, opt => opt.MapFrom(s => s.Genres.Select(sel => sel.GenreName).ToList()))
                .ForMember(c => c.Comments, 
                    opt => opt.MapFrom(
                        s => Mapper.Map<ICollection<Comment>, ICollection<CommentViewModel>>(s.BookReviews)))
                .ForMember(c => c.Authors,
                    opt => opt.MapFrom(
                        s => s.Authors.Select(sel => $"{sel.Surname} {sel.Name} {sel.LastName}").ToList()));
            #endregion  

            #region BokInstance -> bookVM
            CreateMap<BookInstance, BookViewModel>()
                .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Book.Description))
                .ForMember(b => b.PublicationHouse, opt => opt.MapFrom(s => s.Book.PublicationHouse))
                .ForMember(b => b.Comments, opt => opt.Ignore())
                .ForMember(b => b.Authors, opt => opt.Ignore())
                .ForMember(b => b.Tags, opt => opt.MapFrom(s => s.Book.Tags.Select(sel => sel.TagName).ToList()))
                .ForMember(b => b.PublicationDate, opt => opt.MapFrom(s => s.Book.DateOfPublication));
            #endregion

            #region User -> userVM
            CreateMap<User, UserViewModel>()
                .ForMember(c => c.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(c=> c.Email, opt => opt.MapFrom(s => s.EMail))
                .ForMember(c => c.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(c => c.CardNumber, opt => opt.MapFrom(s => s.ReaderCardNumber))
                .ForMember(c => c.FullName, opt => opt.MapFrom(s => $"{s.Surname} {s.Name} {s.LastName}"))
                .ForMember(c => c.IsBlocked, opt => opt.MapFrom(s => s.IsBlocked))
                .ForMember(c => c.Login, opt => opt.MapFrom(s => s.Login))
                .ForMember(c => c.WorkerNumber, opt => opt.MapFrom(s => s.WorkerNumber))
                .ForMember(c => c.LibraryNumber, opt => opt.MapFrom(s => s.ReaderCardNumber))
                .ForMember(c => c.UserType, opt => opt.MapFrom(s => s.UserType))
                .ForMember(c => c.BooksHistory, opt => opt.MapFrom(s => Mapper.Map<ICollection<BookInstance>, ICollection<BookViewModel>>(s.BooksHistory)));
            #endregion

            #region LibraryLogRecord -> LibraryLogRecordVM

            CreateMap<LibraryLogRecord, LibraryLogRecordViewModel>()
                .ForMember(l => l.User, opt => opt.MapFrom( s=> Mapper.Map<User, UserViewModel>(s.Reader)))
                .ForMember(l => l.Worker, opt => opt.MapFrom(s => Mapper.Map<User, UserViewModel>(s.Librariant)))
                .ForMember(l => l.RentalTime, opt => opt.MapFrom(s => s.RentalTime))
                .ForMember(l => l.ExpectedReturnTime, opt => opt.MapFrom(s => s.ExpectedReturnTime))
                .ForMember(l => l.RealReturnTime, opt => opt.MapFrom(s => s.ReturnTime))
                .ForMember(l => l.BookInstacneNumber, opt => opt.MapFrom(s => s.BookInstance.LibraryNumber))
                .ForMember(l => l.BookInstanceNameTitle, opt => opt.MapFrom(s => s.BookInstance.Book.Title))
                .ForMember(l => l.Id, opt => opt.MapFrom(s => s.Id));

            #endregion

            #region UserVM -> User
            CreateMap<UserViewModel, User>()
                .ForMember(u => u.Name, opt => opt.MapFrom(s => s.FullName.Split(' ')[1]))
                .ForMember(u => u.Surname, opt => opt.MapFrom(s => s.FullName.Split(' ')[0]))
                .ForMember(u => u.LastName, opt => opt.MapFrom(s=>  s.FullName.Split(' ')[2]))
                .ForMember(u => u.EMail, opt => opt.MapFrom(s => s.Email))
                .ForMember(u => u.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(u => u.IsBlocked, opt => opt.MapFrom(s => s.IsBlocked));
            #endregion

            #region CommentVM-> comment
            CreateMap<CommentViewModel, Comment>()
                .ForMember(c => c.Rating, opt => opt.MapFrom(s => s.Rating))
                .ForMember(c => c.PublicationDateTime, opt => opt.MapFrom(s => DateTime.UtcNow))
                .ForMember(c => c.Review, opt => opt.MapFrom(s => s.Review))
                .ForMember(c => c.Reviewer, opt => opt.MapFrom(s => Mapper.Map<UserViewModel, User>(s.Reviewer)))
                .ForMember(c => c.Book, opt => opt.MapFrom(s => Mapper.Map<BookViewModel, Book>(s.Book))); //TODO: change this map
            #endregion
            
            #region string => Author

            CreateMap<string, Author>()
                .ForMember(a => a.Name, opt => opt.MapFrom(s => s.Split(' ')[1]))
                .ForMember(a => a.Surname, opt => opt.MapFrom(s => s.Split(' ')[0]))
                .ForMember(a => a.LastName, opt => opt.MapFrom(s => s.Split(' ')[2]));
            #endregion

            #region string => Tag

            CreateMap<string, Tag>().ForMember(t => t.TagName, opt => opt.MapFrom(s=> s));

            #endregion

            #region string => Genre

            CreateMap<string, Genre>().ForMember(t => t.GenreName, opt => opt.MapFrom(s => s));

            #endregion

            #region BookVM -> book
            CreateMap<BookViewModel, Book>()
                .ForMember(b => b.Authors, opt => opt.MapFrom(s => Mapper.Map<ICollection<string>, ICollection<Author>>(s.Authors)))
                .ForMember(b => b.PublicationHouse, opt => opt.MapFrom(s => s.PublicationHouse))
                .ForMember(b => b.DateOfPublication, opt => opt.MapFrom(s=> s.PublicationDate))
                .ForMember(b=> b.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(b=> b.BookReviews, opt => opt.MapFrom(s => Mapper.Map<IEnumerable<CommentViewModel>, IEnumerable<Comment>>(s.Comments)))
                .ForMember(b => b.Genres, opt => opt.MapFrom(s => Mapper.Map<IEnumerable<string>, IEnumerable<Genre>>(s.Genres)))
                .ForMember(b => b.Tags, opt => opt.MapFrom(s => Mapper.Map<IEnumerable<string>, IEnumerable<Tag>>(s.Tags)))
                .ForMember(b=> b.Title, opt => opt.MapFrom(s => s.Title));

            #endregion

            #region RegistrationVM -> user

            CreateMap<RegistrationViewModel, User>()
                .ForMember(u => u.EMail, opt => opt.MapFrom(s => s.Email))
                .ForMember(u => u.Login, opt => opt.MapFrom(s => s.Login))
                .ForMember(u => u.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(u => u.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(u => u.Surname, opt => opt.MapFrom(s => s.Surname))
                .ForMember(u => u.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(u => u.Birthday, opt => opt.MapFrom(s => DateTime.Parse(s.Birthday)))
                .ForMember(u => u.UserType, opt => opt.MapFrom(s => UserType.Consumer));

            #endregion

            #region UserSettingsVM -> User

            CreateMap<UserSettingsViewModel, User>()
                .ForMember(u => u.EMail, opt => opt.MapFrom(s => s.Email))
                .ForMember(u => u.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(u => u.Surname, opt => opt.MapFrom(s => s.Surname))
                .ForMember(u => u.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(u => u.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(u => u.Birthday, opt => opt.MapFrom(s => s.Birthday.Date))
                .ForMember(u => u.HiringDate, opt => opt.Ignore())
                .ForMember(u => u.Login, opt => opt.Ignore())
                .ForMember(u => u.WorkerNumber, opt => opt.Ignore())
                .ForMember(u => u.UserType, opt => opt.Ignore())
                .ForMember(u => u.Id, opt => opt.Ignore());

            #endregion

            #region ExpandedSettingsVM -> User

            CreateMap<ExpandedSettingsViewModel, User>()
                .ForMember(u => u.UserType, opt => opt.MapFrom(s => s.UserType))
                .ForMember(u => u.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(u => u.Surname, opt => opt.MapFrom(s => s.Surname))
                .ForMember(u => u.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(u => u.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(u => u.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(u => u.ReaderCardNumber, opt => opt.MapFrom(s => s.LibraryNumber))
                .ForMember(u => u.WorkerNumber, opt => opt.MapFrom(s => s.WorkerNumber))
                .ForMember(u => u.EMail, opt => opt.MapFrom(s => s.Email))
                .ForMember(u => u.IsBlocked, opt => opt.MapFrom(s => s.IsBlocked))
                .ForMember(u => u.Id, opt => opt.MapFrom(s=>s.UserId));

            #endregion

            #region BookChangeVM -> Book

            CreateMap<BookChangeViewModel, Book>()
                .ForMember(b => b.Authors, opt => opt.MapFrom(s => Mapper.Map<string, IEnumerable<Author>>(s.Authors)))
                .ForMember(b => b.Tags, opt => opt.MapFrom(s => Mapper.Map<string, IEnumerable<Tag>>(s.Tags)))
                .ForMember(b => b.Genres, opt => opt.MapFrom(s => Mapper.Map<string, IEnumerable<Genre>>(s.Genres)))
                .ForMember(b => b.DateOfPublication, opt => opt.MapFrom(s => int.Parse(s.PublicationDate)))
                .ForMember(b => b.PublicationHouse, opt => opt.MapFrom(s => s.PubHouse))
                .ForMember(b => b.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Description));

            #endregion
        }
    }
}