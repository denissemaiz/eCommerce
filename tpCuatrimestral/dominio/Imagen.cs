using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        private int id;
        private int idArticulo;
        private string nombre;
        private string url;

        public Imagen()
        {

        }

        public Imagen(int id, int idArticulo, string nombre, string url)
        {
            this.id = id;
            this.idArticulo = idArticulo;
            this.url = url;
            this.nombre = nombre;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdArticulo
        { 
            get { return idArticulo; } 
            set { idArticulo = value; } 
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Url 
        {
            get { return url; }
            set { url = value; }
        }
    }
}
