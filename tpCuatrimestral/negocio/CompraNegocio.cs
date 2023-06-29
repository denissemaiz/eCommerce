using Clases;
using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Conexiones
{
    public class CompraNegocio
    {
        public List<Compra> Listar()
        {
            List<Compra> lista = new List<Compra>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("SELECT C.ID_Compra, L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, L.Stock, G.ID_Genero, G.Nombre AS GeneroNombre, G.Descripcion AS GeneroDescripcion, A.ID_Autor, A.Nombre AS AutorNombre, A.Apellido AS AutorApellido " +
                                "FROM Compra C " +
                                "INNER JOIN Compra_X_Libro CL ON C.ID_Compra = CL.ID_Compra " +
                                "INNER JOIN Libro L ON CL.ID_Libro = L.ID_Libro " +
                                "INNER JOIN Libro_X_Autor LA ON L.ID_Libro = LA.ID_Libro " +
                                "INNER JOIN Autor A ON LA.ID_Autor = A.ID_Autor " +
                                "INNER JOIN Genero_X_Libro GL ON L.ID_Libro = GL.ID_Libro " +
                                "INNER JOIN Genero G ON GL.ID_Genero = G.ID_Genero");

                Datos.EjecutarLectura();

                Dictionary<int, Compra> compras = new Dictionary<int, Compra>();

                while (Datos.Lector.Read())
                {
                    int idCompra = (int)Datos.Lector["ID_Compra"];
                    int idLibro = (int)Datos.Lector["ID_Libro"];

                    Compra auxCompra;
                    if (!compras.ContainsKey(idCompra))
                    {
                        auxCompra = new Compra();
                        auxCompra.Id = idCompra;
                        auxCompra.Carrito = new Carrito();
                        auxCompra.Carrito.Libros = new List<Libro>();
                        auxCompra.Carrito.Monto = 0;

                        compras.Add(idCompra, auxCompra);
                    }
                    else
                    {
                        auxCompra = compras[idCompra];
                    }

                    Libro auxLibro = new Libro();
                    auxLibro.Id = idLibro;
                    auxLibro.Codigo = (string)Datos.Lector["Codigo"];
                    auxLibro.Titulo = (string)Datos.Lector["Titulo"];
                    auxLibro.Descripcion = (string)Datos.Lector["Descripcion"];
                    auxLibro.Precio = (decimal)Datos.Lector["Precio"];
                    auxLibro.Stock = (int)Datos.Lector["Stock"];

                    if (auxCompra.Carrito != null && auxCompra.Carrito.Libros != null)
                    {
                        auxCompra.Carrito.Libros.Add(auxLibro);
                        auxCompra.Carrito.Monto += auxLibro.Precio;
                    }

                    Autor auxAutor = new Autor();
                    auxAutor.Id = (int)Datos.Lector["ID_Autor"];
                    auxAutor.Nombre = (string)Datos.Lector["AutorNombre"];
                    auxAutor.Apellido = (string)Datos.Lector["AutorApellido"];

                    auxLibro.Autores = new List<Autor>();
                    auxLibro.Autores.Add(auxAutor);

                    Genero auxGenero = new Genero();
                    auxGenero.Id = (int)Datos.Lector["ID_Genero"];
                    auxGenero.Nombre = (string)Datos.Lector["GeneroNombre"];
                    auxGenero.Descripcion = (string)Datos.Lector["GeneroDescripcion"];

                    auxLibro.Generos = new List<Genero>();
                    auxLibro.Generos.Add(auxGenero);

                    lista.Add(auxCompra);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public void Agregar(Compra nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.IniciarTransaccion();

                int idCompra = InsertarCompra(nuevo);

                foreach (Libro libro in nuevo.Carrito.Libros)
                {
                    int cantidad = CalcularCantidadLibros(nuevo.Carrito.Libros, libro.Id);
                    InsertarLibroEnCompra(idCompra, libro.Id, cantidad);
                    DescuentoStock(libro.Id, cantidad);
                }

                datos.CompletarTransaccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(Compra compra)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.IniciarTransaccion();

                datos.Consulta("DELETE FROM Compra_X_Libro WHERE ID_Compra = " + compra.Id);
                datos.EjecutarAccion();

                foreach (Libro libro in compra.Carrito.Libros)
                {
                    int cantidad = CalcularCantidadLibros(compra.Carrito.Libros, libro.Id);
                    InsertarLibroEnCompra(compra.Id, libro.Id, cantidad);
                    DescuentoStock(libro.Id, cantidad);
                }

                datos.Consulta("UPDATE Compra SET PrecioTotal = " + compra.Carrito.Monto + " WHERE ID_Compra = " + compra.Id);
                datos.EjecutarAccion();

                datos.CompletarTransaccion();
            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion();
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        private int CalcularCantidadLibros(List<Libro> libros, int idLibro)
        {
            int cantidad = 0;

            foreach (Libro libro in libros)
            {
                if (libro.Id == idLibro)
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        private void InsertarLibroEnCompra(int idCompra, int idLibro, int cantidad)
        {
            AccesoSQL datos = new AccesoSQL();

            datos.Consulta("INSERT INTO Compra_X_Libro (ID_Compra, ID_Libro, Cantidad) VALUES(" + idCompra + ", " + idLibro + ", " + cantidad + ")");
            datos.EjecutarAccion();
        }


        private int InsertarCompra(Compra nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            datos.Consulta("INSERT INTO Compra (ID_Cliente, PrecioTotal) VALUES('" + nuevo.IdCliente + "', '" + nuevo.Carrito.Monto + "''); " +
                      "SELECT SCOPE_IDENTITY();");

            return Convert.ToInt32(datos.EjecutarScalar());
        }

        private void DescuentoStock(int idLibro, int cantidadComprada)
        {
            AccesoSQL datos = new AccesoSQL();

            datos.Consulta("UPDATE Libro SET Stock = Stock - " + cantidadComprada + " WHERE ID_Libro = " + idLibro);
            datos.EjecutarAccion();
        }

        public List<Compra> RemoveDuplicadosCompra(List<Compra> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Compra> finalList = new List<Compra>();
            foreach (Compra comp in inputList)
            {
                if (!uniqueStore.ContainsKey(comp.Id.ToString()))
                {
                    uniqueStore.Add(comp.Id.ToString(), "0");
                    finalList.Add(comp);
                }
            }
            return finalList;
        }
    }

}
