using System;
using System.Collections.Generic;
using signalr_netcore.Models;

namespace signalr_netcore.Managers
{
    public static class NotificationManager
    {
        
        public static List<NotificationModel> GetData()
        {
            return new List<NotificationModel>()
            {
                new NotificationModel { Title = "Title 1",Message = "Message 1"},          
                new NotificationModel { Title = "Title 2",Message = "Message 2"},
                new NotificationModel { Title = "Title 3",Message = "Message 3"}
            };
        }
    }
}