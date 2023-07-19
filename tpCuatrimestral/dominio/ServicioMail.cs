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
            server.Credentials = new NetworkCredential("c2d95ed84f907e", "84ec398023bce1");
            server.EnableSsl = true;
            server.Port = 465;
            server.Host = "sandbox.smtp.mailtrap.io";
            
        }

        public void EnviarEnlaceRecuperacion(string CorreoUsuario, string EnlacedePassword) 
        {
            email = new MailMessage();
            email.From = new MailAddress("Noreply@EditorialUTN.com");
            email.To.Add(CorreoUsuario);
            email.Subject = "Recuperar contraseña";
            email.Body = $"Hola, aca te dejamos el enlace para que puedas generar tu nueva contraseña, haz click aqui: {EnlacedePassword}";
            
            server.Send(email);
        }

    }
}
