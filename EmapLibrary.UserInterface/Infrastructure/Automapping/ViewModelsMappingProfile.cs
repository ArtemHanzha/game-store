using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EmapLibrary.UserInterface.ViewModels;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.Infrastructure.Automapping
{
    public class ViewModelsMappingProfile : Profile
    {
        public ViewModelsMappingProfile()
        {
            CreateMap<Comment, CommentViewModel>()
                .ForMember(c => c.BookId, opt => opt.MapFrom(s => s.Book.Id))
                .ForMember(c => c.Rating, opt => opt.MapFrom(s => (int)s.Rating))
                .ForMember(c => c.Review, opt => opt.MapFrom(s => s.Review))
                .ForMember(c => c.ReviewerFullName, opt => opt.MapFrom(s => $"{s.Reviewer.Surname} {s.Reviewer.Name} {s.Reviewer.LastName}"))
                .ForMember(c => c.ReviewerId, opt => opt.MapFrom(s => s.Reviewer.Id));

            CreateMap<Book, BookViewModel>()
                .ForMember(c=>  c.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(c => c.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(c => c.PublicationHouse, opt => opt.MapFrom(s => s.PublicationHouse))
                .ForMember(c => c.PublicationDate, opt => opt.MapFrom(sel => sel.DateOfPublication))
                .ForMember(c => c.Tags, opt => opt.MapFrom(s => s.Tags.Select(sel => sel.TagName).ToList()))
                .ForMember(c => c.Comments, 
                    opt => opt.MapFrom(
                        s => Mapper.Map<ICollection<Comment>, ICollection<CommentViewModel>>(s.BookReviews)))
                .ForMember(c => c.Authors,
                    opt => opt.MapFrom(
                        s => s.Authors.Select(sel => $"{sel.Surname} {sel.Name} {sel.LastName}").ToList()));

            CreateMap<BookInstance, BookViewModel>()
                .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Book.Description))
                .ForMember(b => b.PublicationHouse, opt => opt.MapFrom(s => s.Book.PublicationHouse))
                .ForMember(b => b.Comments, opt => opt.Ignore())
                .ForMember(b => b.Authors, opt => opt.Ignore())
                .ForMember(b => b.Tags, opt => opt.MapFrom(s => s.Book.Tags.Select(sel => sel.TagName).ToList()))
                .ForMember(b => b.PublicationDate, opt => opt.MapFrom(s => s.Book.DateOfPublication));

            CreateMap<Consumer, ConsumerViewModel>()
                .ForMember(c => c.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(c => c.CardNumber, opt => opt.MapFrom(s => s.ReaderCardNumber))
                .ForMember(c => c.FullName, opt => opt.MapFrom(s => $"{s.Surname} {s.Name} {s.LastName}"))
                .ForMember(c => c.IsBlocked, opt => opt.MapFrom(s => s.IsBlocked))
                .ForMember(c => c.Login, opt => opt.MapFrom(s => s.Login))
                .ForMember(c => c.BooksHistory, opt => opt.MapFrom(s => Mapper.Map<ICollection<BookInstance>, ICollection<BookViewModel>>(s.BooksHistory)));

            CreateMap<Worker, WorkerViewModel>()
                .ForMember(w => w.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(w => w.FullName, opt => opt.MapFrom(s => $"{s.Surname} {s.Name} {s.LastName}"))
                .ForMember(w => w.HiringDate, opt => opt.MapFrom(s => s.HiringDate))
                .ForMember(w => w.Login, opt => opt.MapFrom(s => s.Login))
                .ForMember(w => w.WorkerNumber, opt => opt.MapFrom(s => s.WorkerNumber))
                .ForMember(w => w.Type, opt => opt.MapFrom(s => nameof(s.WorkerType)))
                .ForMember(w => w.BooksHistory, opt => opt.MapFrom(s => Mapper.Map<ICollection<BookInstance>, ICollection<BookViewModel>>(s.BooksHistory)));
        }
    }
}