using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.BLL.IntegrationTest.Extensions
{
    using Newtonsoft.Json;

    using TechnicalStation.Core.Dto.Notification;

    public static class Extensions
    {
        public static string ToText(this NotificationInfo notificationInfo)
        {
            string s = JsonConvert.SerializeObject(notificationInfo.AttachedObject);
            return $"Type: {notificationInfo.NotificationType} AttachedMessage: {notificationInfo.AttachedMessage} AttachedObject: {s}";
        }
    }
}
