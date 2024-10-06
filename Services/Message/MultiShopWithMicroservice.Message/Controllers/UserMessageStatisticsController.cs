using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.Message.Services;

namespace MultiShopWithMicroservice.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageStatisticsController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageStatisticsController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }
        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var values = await _userMessageService.GetTotalMessageCount();
            return Ok(values);
        }

        [HttpGet("GetMessageCountByReceiverId/{id}")]

        public async Task<IActionResult> GetMessageCountByReceiverId(string id)
        {
            var values = await _userMessageService.GetMessageCountByReceiverIdAsync(id);
            return Ok(values);
        }
    }
}
