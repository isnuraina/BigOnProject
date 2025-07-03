namespace Bigon.İnfrastructure.Services.Abstracts
{
    public interface IEmailService
    {
        Task<bool> SendMailAsync(string to, string subject, string body);
        //bool SendMailAsync(string to, string subject, string body);
    }
}
