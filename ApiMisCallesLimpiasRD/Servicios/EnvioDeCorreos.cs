using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Servicios
{
    public class EnvioDeCorreos
    {
        public void Enviarcorreo(string email, string subject, string message) 
        {
            Task.Run(() =>
            {
                string from = "lofisoftware00@gmail.com";
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(from, "Marcosjb1"),
                    EnableSsl = true,
                };
                MailMessage mailMessage = new MailMessage(from, email);
                mailMessage.Body = message;
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;

                smtpClient.Send(mailMessage);
            });
        }
    }
}
