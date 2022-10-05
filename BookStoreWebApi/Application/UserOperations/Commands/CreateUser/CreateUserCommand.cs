using AutoMapper;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateUserCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public void Handle()
        {

            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);

            if (user is not null)
            {
                throw new InvalidOperationException("Bu Kullanıcı Sisteme Kayıtlı");
            }

            user = _mapper.Map<User>(Model);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

        }


        //bir kitap kaydetmek istediğimizde dışardan ne almamız gerekiyorsa onu yazarız
        public class CreateUserModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }



    }
}