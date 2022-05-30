using ApiPart.Hubs;
using ApiPart.ReqDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ApiPart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("send")]
        [HttpPost]
        public IActionResult SendRequest([FromBody] MessageDto msg)
        {
            _hubContext.Clients.All.SendAsync("ReceiveOne", msg.user, msg.msgText);
            return Ok();
        }

     
    }
}
