namespace TechnicalStation.Core.BLL.Contract
{
    using System.Threading.Tasks;

    using TechnicalStation.Core.Dto.Notification;

    public interface INotificationService
    {
        Task Notify(NotificationInfo notificationInfo);

        //Task NotifyUser(int userId, NotificationInfo notificationInfo);

        //Task JoinNotificationGroup(string groupName, int userId, string connectionId);

        //Task LeaveNotificationGroup(string groupName, int id, string connectionId);
    }
}
