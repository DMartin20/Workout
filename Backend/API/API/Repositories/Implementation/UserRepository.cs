using API.Context;
using API.Models.Domain;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> AuthenticateAsync(User user)
        {
            var authenticatedUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);

            return authenticatedUser;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return user;
        }
    }
}
