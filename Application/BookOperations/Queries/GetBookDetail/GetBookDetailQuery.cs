using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var existingBook = _dbContext.Books.Include(book => book.Genre).Where(book => book.Id == BookId).SingleOrDefault();
            if (existingBook is null)
                throw new InvalidOperationException("Kitap bulunamadı!!!");

            BookDetailViewModel viewModel = _mapper.Map<BookDetailViewModel>(existingBook);

            return viewModel;
        }
    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
