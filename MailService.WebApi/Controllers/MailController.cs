using MailService.WebApi.Models;
using MailService.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;

        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        /// <summary>
        /// method for sending email with attachment
        /// </summary>
        /// <param name="request">email body and attachments</param>
        /// <returns>status code 200 - Ok</returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok("Email successfully sent!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        /// <summary>
        /// welcome email method
        /// </summary>
        /// <param name="request">email and username</param>
        /// <returns>status code 200 - Ok</returns>
        [HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeMail([FromForm] WelcomeRequest request)
        {
            try
            {
                await mailService.SendWelcomeEmailAsync(request);
                return Ok("Email successfully sent!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
