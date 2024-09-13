namespace TechnicalStation.Service.Core.Controller
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    using TechnicalStation.Core.BLL.Contract;
    using TechnicalStation.Core.BLL.Contract.Extensions;
    using TechnicalStation.Core.Dto.Notification;
    using TechnicalStation.Service.Core.Hub;

    
        public class NotificationService : INotificationService
        {
            private readonly IHubContext<MainHub> hubContext;

            public NotificationService(IHubContext<MainHub> hubContext)
            {
                this.hubContext = hubContext;
            }

            public async Task Notify(NotificationInfo notificationInfo)
            {
                await hubContext.Clients.All.SendAsync("Notify", notificationInfo);
            }

            public async Task NotifyUser(int userId, NotificationInfo notificationInfo)
            {
                string groupId = userId.ToGroupId("u");
                await hubContext.Clients.Group(groupId).SendAsync("Notify", notificationInfo);
            }

            public async Task JoinNotificationGroup(string groupName, int id, string connectionId)
            {
                string groupId = string.Concat(groupName, id.ToGroupId());
                await hubContext.Groups.AddToGroupAsync(connectionId, groupId);
            }

            public async Task LeaveNotificationGroup(string groupName, int id, string connectionId)
            {
                string groupId = string.Concat(groupName, id.ToGroupId());
                await hubContext.Groups.RemoveFromGroupAsync(connectionId, groupId);
            }

        }
    }
