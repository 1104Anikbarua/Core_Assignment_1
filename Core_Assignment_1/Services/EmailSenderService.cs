using System.Net;
using System.Net.Mail;

namespace Core_Assignment_1.Services
{

    public class EmailSenderService
    {
        public bool sendEmail(string toEmail) {
            var smtpProvider = "smtp.gmail.com";
            var port = 587;
            var userName = "anikbb04@gmail.com";
            var fromEmail = "anikbb04@gmail.com";
            var password = Environment.GetEnvironmentVariable("app_pass", EnvironmentVariableTarget.User);
            try {
            using (var client = new SmtpClient(smtpProvider, port))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(userName,password);
                    var mail = new MailMessage
                    {
                        From = new MailAddress(fromEmail),
                        Subject = "Registration Success",
                        Body = "Simple Registration Email",
                        IsBodyHtml = true

                    };
                    mail.To.Add(toEmail);
                    client.Send(mail);

                }
                    return true;
            }
            catch(Exception ex){

                return false;

            }
        }  
        
    }
}
