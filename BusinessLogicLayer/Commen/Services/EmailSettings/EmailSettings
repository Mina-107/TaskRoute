
namespace BusinessLogicLayer.SI.Common.Services.EmailSettings
{
    public class EmailSettings : IEmailSettings
    {
        public  void  SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("mn.magdy455@gmail.com", "qrvxurmqkydwkhlf");//Generate Password
            client.Send("mn.magdy455@gmail.com", email.To, email.Subject, email.Body);
           
        }

    }

}

