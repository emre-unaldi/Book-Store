using AutoMapper;
using BookStore.Application.GenreOperations.Commands.CreateGenre;
using BookStore.Application.GenreOperations.Commands.DeleteGenre;
using BookStore.Application.GenreOperations.Commands.UpdateGenre;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.Application.GenreOperations.Queries.GetGenres;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery getGenresQuery = new GetGenresQuery(_context, _mapper);
            var result = getGenresQuery.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery getGenreDetailQuery = new GetGenreDetailQuery(_context, _mapper);
            getGenreDetailQuery.GenreId = id;

            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(getGenreDetailQuery);

            var result = getGenreDetailQuery.Handle();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddGenre([FromBody] CreateGenreModel createGenreModel)
        {
            CreateGenreCommand createGenreCommand = new CreateGenreCommand(_context);
            createGenreCommand.Model = createGenreModel;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(createGenreCommand);

            createGenreCommand.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenreModel)
        {
            UpdateGenreCommand updateGenreCommand = new UpdateGenreCommand(_context);
            updateGenreCommand.GenreId = id;
            updateGenreCommand.Model = updateGenreModel;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(updateGenreCommand);

            updateGenreCommand.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand deleteGenreCommand = new DeleteGenreCommand(_context);
            deleteGenreCommand.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(deleteGenreCommand);

            deleteGenreCommand.Handle();    
            return Ok();
        }
    }
}
