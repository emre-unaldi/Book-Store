using BookStore.DBOperations;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var exitingBook = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);


            if (exitingBook is null)
                throw new InvalidOperationException("Silinecek kitap bulunamadı!!!");

            _dbContext.Books.Remove(exitingBook);
            _dbContext.SaveChanges();
        }
    }
}
