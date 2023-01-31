using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Auth.Core.Helpers.Interface
{
    public interface IHelper
    {
        void CreatePasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt);
        bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt);
    }
}
