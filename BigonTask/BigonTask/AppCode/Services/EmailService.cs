using BigonTask.Models.Entities;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace BigonTask.AppCode.Services
{
    public class EmailService : SmtpClient,IEmailService
    {
        private readonly EmailOptions options;

        public EmailService(IOptions<EmailOptions> options)
        {
            this.options = options.Value;
            this.Credentials = new NetworkCredential(this.options.userName, this.options.password);
            this.EnableSsl = true;
            this.Host = this.options.smtpServer;
            this.Port = this.options.smtpPort;
         
        }
        public async Task<bool> SendMailAsync(string to, string subject, string body)
        {

            try
            {

                SmtpClient client = new SmtpClient(options.smtpServer, options.smtpPort);
               
                MailMessage message = new MailMessage();
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.To.Add(to);
                message.From = new MailAddress(options.userName, options.displayName);
                await this.SendMailAsync(message);
            }

            catch (Exception)
            {

              return false;
            }


            return true;
        }
    }
}
