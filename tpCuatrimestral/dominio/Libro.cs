using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Libro
    {
        private int id;
        private string codigo;
        private string titulo;
        private List<Autor> autores;
        private string descripcion;
        private decimal precio;
        private int stock;
        private List<Genero> generos;
        private string portadaURL;

        private bool activo;

        public Libro()
        {
            activo = true;
            this.autores = new List<Autor>();
            this.generos = new List<Genero>();
        }

        public Libro(int id, string codigo, string titulo, List<Autor> autores, string descripcion, decimal precio, int stock, List<Genero> generos, string portadaURL)
        {
            this.id = id;
            this.codigo = codigo;
            this.titulo = titulo;
            this.autores = autores;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
            this.generos = generos;
            this.portadaURL = portadaURL;

            activo = true;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }

        }
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public List<Autor> Autores
        {
            get { return autores; } 
            set { autores = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public List<Genero> Generos
        {
            get { return generos; }
            set { generos = value; }
        }

        public string PortadaURL
        {
            get { return portadaURL; }
            set { portadaURL = value; }
        }

        public bool Activo
        {
            get { return activo; }
        }

        public string CadenaAutores
        {
            get { return ListarAutores(); }
        }


        public string ListarGenero()
        {
            string cadena = "";
            int i = 0;
            foreach (Genero genero in generos)
            {
                if (i == 0)
                    cadena = genero.ToString();
                else
                    cadena += ", " + genero.ToString();
                i++;
            }
            return cadena;
        }


        public string ListarAutores()
        {
            string cadena="";
            int i = 0;
            foreach (Autor autor in autores)
            {
                if (i == 0)
                    cadena = autor.ToString();
                else
                    cadena += ", " + autor.ToString();
                i++;
            }
            return cadena;
        }


        public void bajaLogica()
        {
            activo = false;
        }

        public override string ToString()
        {
            return this.codigo + " - " + this.titulo;
        }
    }
}
