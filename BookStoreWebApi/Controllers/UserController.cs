using AutoMapper;
using BookStoreWebApi.Application.UserOperations.Commands.CreateUser;
using BookStoreWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;
using Microsoft.Extensions.Configuration;
using BookStoreWebApi.TokenOperations.Models;
using BookStoreWebApi.Application.UserOperations.Commands.CreateToken;
using Microsoft.AspNetCore.Authorization;
using BookStoreWebApi.Application.UserOperations.Commands.RefreshToken;

namespace BookStoreWebApi.Controllers
{
    [Authorize]
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

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _mapper, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }



    }
}