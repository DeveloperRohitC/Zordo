using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Zordo.Helper
{
    class ExceptionEmail
    {
        public void SendMail(string msg)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("rohitdude.april@gmail.com");
                mail.To.Add("rohitdude.april@gmail.com");
                mail.Subject = "Error : Delivery@Door App";
                mail.Body = "Exception : " + msg;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("rohitdude.april@gmail.com", "AAAAA");
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Send(mail);
            }

            catch (Exception ex)
            {

            }
        }
    }
}
