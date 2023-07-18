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
            server.Credentials = new NetworkCredential("Acavaelmail@mail","Proeycto");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        
        }


    }
}
