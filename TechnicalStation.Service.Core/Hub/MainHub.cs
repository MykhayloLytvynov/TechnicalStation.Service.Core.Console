using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.SignalR;
using TechnicalStation.Service.Domain.Transform;
using TechnicalStation.Service.Hub;

namespace TechnicalStation.Service.Core.Hub
{
    public partial class MainHub : Microsoft.AspNetCore.SignalR.Hub
    {
        /// <summary>
        /// The connection collection. Stores the active connections.
        /// </summary>
        protected readonly static List<string> connectionCollection = new List<string>();
        private readonly OrderTransformer orderTransformer;
        private readonly CarTransformer carTransformer;
        private readonly CustomerTransformer customerTransformer;
        private readonly UserInfoTransformer userTransformer;
        private readonly WorkTransformer workTransformer;
        private readonly WorkerTransformer workerTransformer;
        /// <summary>
        /// The locker.
        /// </summary>
        protected static readonly object locker = new object();

        private HubEnvironment hubEnvironment;

        private ILog log;

        public MainHub(HubEnvironment hubEnvironment, ILog log)
        {
            this.hubEnvironment = hubEnvironment;
            this.log = log;
            this.orderTransformer = new OrderTransformer();
            this.userTransformer = new UserInfoTransformer();
            this.carTransformer = new CarTransformer();
            this.customerTransformer = new CustomerTransformer();
            this.workTransformer = new WorkTransformer();
            this.workerTransformer = new WorkerTransformer();
        }

        /// <summary>
        /// Gets or sets a value indicating whether is user entered.
        /// </summary>
        protected virtual bool IsUserEntered
        {
            get
            {
                return connectionCollection.Contains(this.Context.ConnectionId);
            }
        }

        /// <summary>
        /// The add connection.
        /// </summary>
        /// <param name="connectionId">
        /// The connection id.
        /// </param>
        protected void AddConnection(string connectionId)
        {
            lock (locker)
            {
                if (!connectionCollection.Contains(connectionId))
                {
                    connectionCollection.Add(connectionId);
                }
            }
        }

        /// <summary>
        /// The remove connection.
        /// </summary>
        /// <param name="connectionId">
        /// The connection id.
        /// </param>
        protected void RemoveConnection(string connectionId)
        {
            lock (locker)
            {
                if (connectionCollection.Contains(connectionId))
                {
                    connectionCollection.Remove(connectionId);
                }
            }
        }

        /// <summary>
        /// The join group.
        /// </summary>
        /// <param name="groupName">
        /// The group.
        /// </param>
        protected void JoinGroup(string groupName)
        {
            this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
        }

        /// <summary>
        /// The leave group.
        /// </summary>
        /// <param name="groupName">
        /// The group name.
        /// </param>
        protected void LeaveGroup(string groupName)
        {
            this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, groupName);
        }

        //public async Task Send(string message)
        //{
        //    Console.Write(message);
        //    await this.Clients.All.SendAsync("Notify", message);
        //}

        protected string GetIpAddress()
        {
            var ipAddress = Context.GetHttpContext().Connection.RemoteIpAddress.ToString();

            return ipAddress;
        }
    }
}
