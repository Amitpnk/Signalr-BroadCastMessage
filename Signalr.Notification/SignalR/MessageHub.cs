using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Signalr.Notification.SignalR
{
    public class MessageHub : Hub
    {
        [HubMethodName("Send_Message")]
        public void SendMessage(string msg)
        {

            Clients.Others.NotifyUser(msg);
        }
    }


    public class Notify
    {
        public static void BroadCast (string msg)
        {

            var AllContext = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            AllContext.Clients.All.GetAllMessage(msg);
        }
    }
}