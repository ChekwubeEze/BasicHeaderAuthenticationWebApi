using Basic.Auth.Core.ModelsDto;
using Basic.Auth.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Auth.Core.Interfaces.UserInterfaces
{
    public interface IUserInterface
    {
        Task Register(CreateUserDto userDto);
        Task<string> LogIn(UserLoginDto loginDto);
    }
}
