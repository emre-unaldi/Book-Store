using AutoMapper;
using BookStore.Application.BookOperations.Commands.CreateBook;
using BookStore.Application.BookOperations.Commands.UpdateBook;
using BookStore.Application.BookOperations.Queries.GetBookDetail;
using BookStore.Application.BookOperations.Queries.GetBooks;
using BookStore.Application.GenreOperations.Commands.CreateGenre;
using BookStore.Application.GenreOperations.Commands.UpdateGenre;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.Application.GenreOperations.Queries.GetGenres;
using BookStore.Application.UserOperations.CreateUser;
using BookStore.Entities;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>()
                .ForMember(dest => dest.Genre,opt => opt.MapFrom(src => src.Genre.Name)).ReverseMap();
            CreateMap<Book, BooksViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ReverseMap();
            CreateMap<UpdateBookModel, Book>().ReverseMap();

            CreateMap<Genre, CreateGenreModel>().ReverseMap();
            CreateMap<Genre, UpdateGenreModel>().ReverseMap();
            CreateMap<Genre, GenresViewModel>().ReverseMap();
            CreateMap<Genre, GenreDetailViewModel>().ReverseMap();

            CreateMap<User, CreateUserModel>().ReverseMap();    
        }
    }
}
