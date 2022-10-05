using AutoMapper;
using BookStoreWebApi.Application.UserOperations.Commands.CreateUser;
using BookStoreWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;
using Microsoft.Extensions.Configuration;

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





    }
}