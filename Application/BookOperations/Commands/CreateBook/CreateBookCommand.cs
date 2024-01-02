using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private IBookStoreDbContext _dbContext;
        private IMapper _mapper;

        public CreateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var existingBook = _dbContext.Books.SingleOrDefault(book => book.Title == Model.Title);

            if (existingBook is not null)
                throw new InvalidOperationException("Kitap zaten mevcut!!!");

            existingBook = _mapper.Map<Book>(Model);

            _dbContext.Books.Add(existingBook);
            _dbContext.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
