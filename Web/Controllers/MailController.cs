using Core.Utilities.Mail;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailHelper _mailHelper;

        public MailController(IMailHelper mailHelper)
        {
            _mailHelper = mailHelper;
        }

        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailModel emailModel)
        {
            try
            {
                _mailHelper.SendMailAsync(emailModel.Subject, emailModel.Body, emailModel.Recepients);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Email send failed: {ex.Message}");
            }
        }
    }
}

