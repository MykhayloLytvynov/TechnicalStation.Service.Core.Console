using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.Domain.User;

namespace TechnicalStation.Core.BLL.Contract
{
    public interface IUserService
    {
        Task<User> GetUserByLoginAsync(string login);
    }
}
