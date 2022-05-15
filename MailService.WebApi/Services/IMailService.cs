using MailService.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailService.WebApi.Services
{
    public interface IMailService
    {
        //sending email with message and attachment
        Task SendEmailAsync(MailRequest mailRequest);
        
        //welcome email sending
        Task SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
