using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Usuario
    {
        public int id;
        public string nombre;
        public string mail;
        public string contraseña;
        public Direccion direccion;

        public Usuario()
        {

        }

        public Usuario(int id, string nombre, string mail, string contraseña, Direccion direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.mail = mail;
            this.contraseña = contraseña;
            this.direccion = direccion;
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
    }
}
