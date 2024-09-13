using System;
namespace TechnicalStation.Core.BLL.Contract
{
    public interface IApplicationServiceFactory
    {
        void ConfigureHandlers(INotificationService notificationService);

        T Create<T>();
    }
}
