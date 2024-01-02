using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı!!!");

            _mapper.Map(Model, book);

            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
    }
}
