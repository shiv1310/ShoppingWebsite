using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace ShoppingHeart
{
    public static class EmailEngine
    {
        public static void SendEmail(string recepientEmail,string subject,string body)
        {
            using (MailMessage mailmeassage=new MailMessage())
            {
                mailmeassage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                mailmeassage.Subject = subject;
                mailmeassage.Body = body;
                mailmeassage.IsBodyHtml = true;
                mailmeassage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred=new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(mailmeassage);
            
            }
        }
    }
}