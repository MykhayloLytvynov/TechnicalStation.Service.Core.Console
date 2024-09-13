using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.Dto.Notification;

namespace TechnicalStation.Core.BLL.IntegrationTest
{

    using TechnicalStation.Core.BLL.IntegrationTest.Extensions;
    public class NotificationService : INotificationService
    {
        public ConcurrentQueue<string> NotificationCollection = new ConcurrentQueue<string>();

        public async Task Notify(NotificationInfo notificationInfo)
        {
            await Task.Run(() =>
            {
                Debug.WriteLine(notificationInfo.ToText());
            });

        }

        //public async Task NotifyUser(int userId, NotificationInfo notificationInfo)
        //{
        //    await Task.Run(() =>
        //    {
        //        this.NotificationCollection.Enqueue($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. UserId: {userId} will be notified " + notificationInfo.ToText());
        //    });
        //}

        //public async Task JoinNotificationGroup(string groupName, int userId, string connectionId)
        //{
        //    await Task.Run(() =>
        //    {
        //        this.NotificationCollection.Enqueue($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. Connection:{connectionId} joins the group: {userId.ToGroupId(groupName)}");
        //    });
        //}

        //public async Task LeaveNotificationGroup(string groupName, int id, string connectionId)
        //{
        //    await Task.Run(() =>
        //    {
        //        this.NotificationCollection.Enqueue($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. Connection:{connectionId} leaves the group: {id.ToGroupId(groupName)}");
        //    });
        //}
    }
}
