using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.Domain.User;

namespace TechnicalStation.Core.BLL
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await Task.Run(() =>
            {
                if (login.Equals("login"))
                {
                    return new User() { Id = 1, Login = "login", Password = "password" };
                }
                else
                {
                    throw new Exception($"The user with the login {login} is not found");
                }
            });
        }
    }
}
