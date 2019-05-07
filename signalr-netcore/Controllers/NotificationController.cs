using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using signalr_netcore.Helpers;
using signalr_netcore.Hubs;
using signalr_netcore.Managers;

namespace signalr_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private IHubContext<NotificationHub> hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        
        public IActionResult Get()
        {
            var timerManager = new TimerHelper(() => hubContext.Clients.All.SendAsync("notificationsdata", NotificationManager.GetData()));
 
            return Ok(new { Message = "Request Completed" });
        }
    }
}