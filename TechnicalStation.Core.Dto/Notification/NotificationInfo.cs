namespace TechnicalStation.Core.Dto.Notification
{
    using TechnicalStation.Core.Dto.Enum;

    public class NotificationInfo
    {
        public NotificationType NotificationType { get; set; }

        public string AttachedMessage { get; set; }

        public object AttachedObject { get; set; }

        //public string GetTrace()
        //{
        //    //string s = new JavaScriptSerializer().SerializeObject(AttachedObject);
        //    return $"Type: {NotificationType} AttachedMessage: {AttachedMessage} AttachedObject: {AttachedObject.ToString()}";
        //}
    }
}
