using BookStore.Common;
using BookStore.DBOperations;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookDetailViewModel Handle()
        {
            var existingBook = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (existingBook is null)
                throw new InvalidOperationException("Kitap bulunamadı!!!");

            BookDetailViewModel viewModel = new BookDetailViewModel();
            viewModel.Title = existingBook.Title;
            viewModel.PageCount = existingBook.PageCount;
            viewModel.PublishDate = existingBook.PublishDate.Date.ToString("dd/MM/yyyy");
            viewModel.Genre = ((GenreEnum)existingBook.GenreId).ToString();

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
