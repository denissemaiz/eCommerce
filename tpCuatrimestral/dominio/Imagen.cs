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
        private string imagenUrl;
        private string imagenNombre;

        public Imagen()
        {

        }

        public Imagen(int id, int idArticulo, string imagenUrl, string imagenName)
        {
            this.id = id;
            this.idArticulo = idArticulo;
            this.imagenUrl = imagenUrl;
            this.imagenNombre = imagenName;
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

        public string ImagenUrl 
        {
            get { return imagenUrl; }
            set { imagenUrl = value; }
        }

        public string ImagenNombre
        {
            get { return imagenNombre; }
            set { imagenNombre = value; }
        }
    }
}
