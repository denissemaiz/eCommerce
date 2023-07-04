using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace Clases
{
    //public enum UserType
    //{
    //    ADMIN=1, CLIENTE=2
    //}
    public class Usuario
    {
        public int id;
        public string username;
        public string mail;
        public string contraseña;
        public bool esAdmin;
        public DatosUsuario datosUsuario;

        public Usuario()
        {

        }

        public Usuario(int id, string username, string mail, string contraseña, bool esAdmin, DatosUsuario datosUsuario)
        {
            this.id = id;
            this.username = username;
            this.mail = mail;
            this.contraseña = contraseña;
            this.esAdmin = esAdmin;
            this.datosUsuario = datosUsuario;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Username
        { 
            get { return username; } 
            set { username = value; } 
        }
        public string Mail
        { 
            get { return mail; } 
            set {  mail = value; } 
        }
        public string Contraseña
        { 
            get { return contraseña;} 
            set { contraseña = value; } 
        }
        public bool EsAdmin
        { 
            get { return esAdmin; } 
            set {  esAdmin = value; } 
        }
        public DatosUsuario DatosUsuario
        {
            get { return datosUsuario; }
            set { datosUsuario = value; }
        }

        public bool ConfirmarContraseña(string confirmar)
        {
            if(Contraseña ==  confirmar) return true;

            return false;
        }

        public string EncriptarPass(string pass)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(pass));

                foreach (byte b in result)
                    sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
        
    }
}
