using System;

namespace p4RazorWebApp.Interfaces;

public interface IMailService
{

    public Task SendEmailAsync(string emailAddress , string subject ,  string body, bool isHtml = true );
}
