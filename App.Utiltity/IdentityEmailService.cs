using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

// Add the SendGrid NuGet package by running:
// dotnet add package SendGrid

namespace App.Utiltity
{
    public class IdentityEmailService : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public IdentityEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}