using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBookCommand;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookControllers : ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;
        // Uygulama içerisinden değiştirilmemesi için readonl yaptık.
        // Sadece constructor içinden set edilsin bidaha edilmesin.

        public BookControllers(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET
        // http://localhost:5043/BookControllers
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_dbContext);
            var result = query.Handle();

            return Ok(result);
        } 
        
        // GET
        // http://localhost:5043/BookControllers/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;

            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_dbContext);
                query.BookId = id;
                result = query.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        /*
            // Query Param
            // http://localhost:5043/BookControllers?id={id}
            [HttpGet]
            public Book Get([FromQuery] string id)
            {
                var book = _dbContext.Books.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
                return book;
            }
        */

        // POST
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_dbContext);

            try
            {
                command.Model = newBook;
                command.Handle();
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // PUT
        // http://localhost:5043/BookControllers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_dbContext);
                command.BookId = id;
                command.Model = updateBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE
        // http://localhost:5043/BookControllers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_dbContext);
                command.BookId = id;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}