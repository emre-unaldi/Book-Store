using AutoMapper;
using BookStore.Application.UserOperations.CreateToken;
using BookStore.Application.UserOperations.CreateUser;
using BookStore.DBOperations;
using BookStore.TokenOperations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsersController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserModel userModel)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = userModel;
            command.Handle();

            return Ok();   
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();

            return token;
        }
        
    }
}
