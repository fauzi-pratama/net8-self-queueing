
using Apps.Models;
using Apps.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController(ITransactionService transactionService, IUserService userService) : ControllerBase
    {
        [HttpPost("post_user")]
        public IActionResult PostUser([FromBody] UserMessage userMessage)
        {
            return Ok(userService.PublishUser(userMessage));
        }

        [HttpPost("post_transaction")]
        public IActionResult PostTransaction([FromBody] TransactionMessage transactionMessage)
        {
            return Ok(transactionService.PublishTransaction(transactionMessage));
        }
    }
}
