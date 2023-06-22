using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcion;
        private decimal precio;
        private int stock;
        private int idCategoria;
        //private List<Categoria> idCategoria;
        private List<int> idImagen;
        //private List<Imagen> imagen;

        public Articulo()
        {

        }

        public Articulo(int id, string codigo, string nombre, string descripcion, decimal precio, int stock, int idCategoria, List<int> idImagen)
        {
            this.id = id;
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
            this.idCategoria = idCategoria;
            this.idImagen = idImagen;
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

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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

        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        public List<int> IdImagen
        {
            get { return idImagen; }
            set { idImagen = value; }
        }
    }
}
