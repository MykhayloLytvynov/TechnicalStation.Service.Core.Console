using System;
using TechnicalStation.Core.Domain.User;
using TechnicalStation.Service.Domain.Data;

namespace TechnicalStation.Service.Domain.Transform
{
    public class UserInfoTransformer
    {
        public UserInfo Transform(User user)
        {
            UserInfo userInfo = new UserInfo(user.Login);

            return userInfo;
        }
    }
}
