using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Autor
    {
        private int id;
        private string nombre;
        private string apellido;
        public string NombreApellido
        {
            get { return string.Format("{0} {1}", nombre, apellido); }
        }


        public Autor()
        {
        }

        public Autor(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
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
        public string Apellido
        { 
            get { return apellido; } 
            set { apellido = value; }
        }

        public override string ToString()
        {
            return nombre + " " + apellido;
        }
    }
}