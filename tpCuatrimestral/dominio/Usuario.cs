using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public enum UserType
    {
        ADMIN=1, CLIENTE=2
    }
    public class Usuario
    {
        private int id;
        private string nombre;
        private string mail;
        private string contraseña;
        private Direccion direccion;
        private UserType tipoUsuario;

        public Usuario()
        {

        }

        public Usuario(int id, string nombre, string mail, string contraseña, Direccion direccion, bool admin)
        {
            this.id = id;
            this.nombre = nombre;
            this.mail = mail;
            this.contraseña = contraseña;
            this.direccion = direccion;

            this.tipoUsuario = admin ? UserType.ADMIN : UserType.CLIENTE;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        { 
            get { return nombre; } 
            set { nombre = value; } 
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
        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public UserType TipoUsuario
        {
            get { return tipoUsuario;} 
            set { tipoUsuario = value;}
        } 
        

        public bool validarAdmin()
        {
            if (this.tipoUsuario == UserType.ADMIN) return true;
            return false;
        }
    }
}
