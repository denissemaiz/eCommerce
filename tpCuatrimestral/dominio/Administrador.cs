using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    internal class Administrador
    {
        public int id;
        public string mail;
        public string contraseña;
        public string nombre;

        public Administrador()
        {

        }

        public Administrador(int id, string mail, string contraseña, string nombre)
        {
            this.id = id;
            this.mail = mail;
            this.contraseña = contraseña;
            this.nombre = nombre;            
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
