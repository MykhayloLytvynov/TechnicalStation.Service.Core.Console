using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Service.Domain.Operation
{
    public class EnterOperation
    {
        private string login;

        private string password;

        public string Login
        {
            get { return login; }
        }

        public string Password
        {
            get { return password; }
        }

        public EnterOperation(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
