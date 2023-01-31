using Basic.Auth.Core.Helpers.Interface;
using Basic.Auth.Core.Interfaces.UserInterfaces;
using Basic.Auth.Core.ModelsDto;
using Basic.Auth.Infrastructure;
using Basic.Auth.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Basic.Auth.Core.Implementations.UserImplementation
{
    public class UserServices : IUserInterface
    {
        private readonly IHelper _helper;
        private readonly BasicAuthDBContext _context;

        public UserServices(IHelper helper, BasicAuthDBContext context)
        {
            _helper = helper;
            _context = context;
        }
        public async Task<string> LogIn(UserLoginDto loginDto)
        {
            string message;
            var user = new User();
            user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user == null)
            {
                message = "Invalid Email";
                return message;
            }
            if (!_helper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                message = "Invalid Password";
                return message;
            }
            message = "User Loged in ";
            return message;
        }

        public async Task Register(CreateUserDto userDto)
        {
            _helper.CreatePasswordHash(userDto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            User user = new User()
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
                Role = userDto.Role,
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

        }
    }
}
