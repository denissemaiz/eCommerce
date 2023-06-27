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
        private int codigo;
        private string titulo;
        private List<Autor> autores;
        private string descripcion;
        private decimal precio;
        private int stock;
        private List<Genero> generos;
        private string portadaURL;

        public Libro()
        {

        }

        public Libro(int id, int codigo, string titulo, List<Autor> autores, string descripcion, decimal precio, int stock, List<Genero> generos, string portadaURL)
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
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Codigo
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
    }
}
