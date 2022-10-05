using AutoMapper;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;
using BookStoreWebApi.TokenOperations;
using BookStoreWebApi.TokenOperations.Models;

namespace BookStoreWebApi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel? Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration? _configuration;

        public CreateTokenCommand(IBookStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;

        }
        public Token Handle()
        {
            //token oluşturma
            //user var mı 
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == Model!.Email && x.Password == Model.Password);
            if (user is not null)
            {
                //token oluştur
                TokenHandler handler = new TokenHandler(_configuration!);

                Token token = handler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                //bu sırada access token alabilmesi için 5 dakika ekledim
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

                _dbContext.SaveChanges();

                return token;





            }
            else
                throw new InvalidOperationException("Email ya da şifre hatalı");


        }
    }

    public class CreateTokenModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}