using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace E_CommerceApp.Services
{
    public class IdentityEmailService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Log email details to the console instead of sending an actual email
            Console.WriteLine($"Sending email to {email} with subject '{subject}' and message: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
}