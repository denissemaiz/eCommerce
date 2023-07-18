using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ServicioMail
    {
        private MailMessage email;
        private SmtpClient server;

        public ServicioMail() 
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("c2d95ed84f907e", "********bce1");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.ios";
        
        }

    }
}
