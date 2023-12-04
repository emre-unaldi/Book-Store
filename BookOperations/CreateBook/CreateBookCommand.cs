using BookStore.DBOperations;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private BookStoreDbContext _dbContext;

        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var existingBook = _dbContext.Books.SingleOrDefault(book => book.Title == Model.Title);

            if (existingBook is not null)
                throw new InvalidOperationException("Kitap zaten mevcut!!!");

            existingBook = new Book();
            existingBook.Title = Model.Title;
            existingBook.PublishDate = Model.PublishDate;
            existingBook.PageCount = Model.PageCount;
            existingBook.GenreId = Model.GenreId;

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
