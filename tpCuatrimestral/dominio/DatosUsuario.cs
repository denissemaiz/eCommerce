using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class DatosUsuario
    {
        public int id;
        public string nombres;
        public string apellidos;
        public Direccion direccion;
        public string telefono;

        public DatosUsuario()
        {

        }

        public DatosUsuario(int id, string nombres, string apellidos, Direccion direccion, string telefono)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        public DatosUsuario(string nombres, string apellidos,  string telefono)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;        
            this.telefono = telefono;
        }

        public int Id
        { 
            get { return id; } 
            set { id = value; }
        }

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        public string Apellidos
        { 
            get { return apellidos; } 
            set { apellidos = value; } 
        }
        public Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Telefono
        { 
            get { return telefono; } 
            set { telefono = value; } 
        }
    }
}
