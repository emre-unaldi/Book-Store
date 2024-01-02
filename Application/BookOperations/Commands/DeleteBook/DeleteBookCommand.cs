using BookStore.DBOperations;

namespace BookStore.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext dbContext)
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
