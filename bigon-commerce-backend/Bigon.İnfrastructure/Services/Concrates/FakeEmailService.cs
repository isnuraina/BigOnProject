﻿using Bigon.İnfrastructure.Services.Abstracts;
using Bigon.İnfrastructure.Services.Configurations;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Bigon.İnfrastructure.Services.Concrates
{
    public class FakeEmailService : SmtpClient,IEmailService
    {
        readonly EmailOptions options;
        public FakeEmailService(IOptions<EmailOptions>options)
        {
            this.options = options.Value;
            this.Host = this.options.SmtpServer;
            this.Port = this.options.SmtpPort;
            this.EnableSsl = true;
            this.Credentials = new NetworkCredential(this.options.UserName, this.options.Password);
        }
        public async Task<bool>SendMailAsync(string to,string subject,string body)
        {
            try
            {
              
                using (MailMessage message = new MailMessage())
                {
                   

                    message.Subject = subject;
                    message.To.Add(to);
                    message.IsBodyHtml = true;
                    message.From = new MailAddress(options.UserName, options.DisplayName);
                    message.Body = body;
                    await base.SendMailAsync(message);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
