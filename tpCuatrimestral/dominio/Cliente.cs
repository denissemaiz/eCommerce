using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    internal class Cliente
    {
        public int id;
        public string mail;
        public string contraseña;
        public string nombre;
        public string apellido;
        public int idDireccion;
        //public Direccion direccion;

        public Cliente()
        {

        }

        public Cliente(int id, string mail, string contraseña, string nombre, string apellido, int idDirecion)
        {
            this.id = id;
            this.mail = mail;
            this.contraseña = contraseña;
            this.nombre = nombre;
            this.apellido = apellido;
            this.idDireccion = idDirecion;
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
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public int IdDireccion
        {
            get { return idDireccion; }
            set { idDireccion = value; }
        }
    }
}
