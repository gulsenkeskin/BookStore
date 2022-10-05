using AutoMapper;
using BookStoreWebApi.Application.UserOperations.Commands.CreateUser;
using BookStoreWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;
using Microsoft.Extensions.Configuration;
using BookStoreWebApi.TokenOperations.Models;
using BookStoreWebApi.Application.UserOperations.Commands.CreateToken;

namespace BookStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {

        private readonly IBookStoreDbContext _context;

        private readonly IMapper _mapper;

        readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);

            command.Model = newUser;
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