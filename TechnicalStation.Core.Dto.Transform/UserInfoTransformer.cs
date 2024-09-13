using System;
using TechnicalStation.Core.Domain.User;
using TechnicalStation.Core.Dto.Data;

namespace TechnicalStation.Core.Dto.Transform
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
