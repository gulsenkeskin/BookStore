using AutoMapper;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;
using BookStoreWebApi.TokenOperations;
using BookStoreWebApi.TokenOperations.Models;

namespace BookStoreWebApi.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IConfiguration? _configuration;

        public RefreshTokenCommand(IBookStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;

        }
        public Token Handle()
        {
            //token oluşturma
            //user var mı 
            var user = _dbContext.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
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
                throw new InvalidOperationException("Geçerli bir refresh token bulunamadı");


        }
    }
}