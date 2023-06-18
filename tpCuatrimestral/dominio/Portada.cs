using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Portada
    {
        private int id;
        private int idLibro;
        private string url;

        public Portada()
        {

        }

        public Portada(int id, int idLibro, string url)
        {
            this.id = id;
            this.idLibro = idLibro;
            this.url = url;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdLibro
        { 
            get { return idLibro; } 
            set { idLibro = value; } 
        }
        public string Url 
        {
            get { return url; }
            set { url = value; }
        }
    }
}
