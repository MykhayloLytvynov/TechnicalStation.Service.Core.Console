using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Dto.Base
{
    public class ConnectionInfo
    {
        private string ip;

        private string connectionId;

        public ConnectionInfo(string ip, string connectionId)
        {
            this.ip = ip;
            this.connectionId = connectionId;
        }

        public string Ip => this.ip;

        public string ConnectionId => this.connectionId;
    }
}
