using Clases;
using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
                Datos.Consulta("SELECT C.ID_Compra, C.FechaCompra, E.TipoEstados, L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, A.ID_Autor, A.Nombre AS AutorNombre, A.Apellido AS AutorApellido " +
                    "FROM Compra C INNER JOIN Compra_X_Libro CL ON C.ID_Compra = CL.ID_Compra " +
                    "INNER JOIN Libro L ON CL.ID_Libro = L.ID_Libro " +
                    "INNER JOIN Estados E ON E.ID_Estado = C.ID_Estado " +
                    "INNER JOIN Libro_X_Autor LA ON L.ID_Libro = LA.ID_Libro " +
                    "INNER JOIN Autor A ON LA.ID_Autor = A.ID_Autor");

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
                        auxCompra.FechaCompra = (DateTime)Datos.Lector["FechaCompra"];
                        auxCompra.Estado = (string)Datos.Lector["TipoEstados"];
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

                    lista.Add(auxCompra);
                }

                lista = groupComprasById(lista);

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

        public List<Compra> Listar(int ID_Usuario)
        {
            List<Compra> lista = new List<Compra>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("SELECT C.ID_Compra, C.FechaCompra, E.TipoEstados, L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, A.ID_Autor, A.Nombre AS AutorNombre, A.Apellido AS AutorApellido " +
                    "FROM Compra C INNER JOIN Compra_X_Libro CL ON C.ID_Compra = CL.ID_Compra " +
                    "INNER JOIN Libro L ON CL.ID_Libro = L.ID_Libro " +
                    "INNER JOIN Estados E ON E.ID_Estado = C.ID_Estado " +
                    "INNER JOIN Libro_X_Autor LA ON L.ID_Libro = LA.ID_Libro " +
                    "INNER JOIN Autor A ON LA.ID_Autor = A.ID_Autor WHERE C.ID_Usuario = " + ID_Usuario);

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
                        auxCompra.FechaCompra = (DateTime)Datos.Lector["FechaCompra"];
                        auxCompra.Estado = (string)Datos.Lector["TipoEstados"];
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

                    lista.Add(auxCompra);
                }

                lista = groupComprasById(lista);

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

        public Compra BuscarCompra(int ID_Compra)
        {
            Compra compra = new Compra();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("SELECT C.ID_Usuario, C.FechaCompra, CL.Cantidad, E.TipoEstados, L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, A.ID_Autor, A.Nombre AS AutorNombre, A.Apellido AS AutorApellido " +
                    "FROM Compra C INNER JOIN Compra_X_Libro CL ON C.ID_Compra = CL.ID_Compra " +
                    "INNER JOIN Libro L ON CL.ID_Libro = L.ID_Libro " +
                    "INNER JOIN Estados E ON E.ID_Estado = C.ID_Estado " +
                    "INNER JOIN Libro_X_Autor LA ON L.ID_Libro = LA.ID_Libro " +
                    "INNER JOIN Autor A ON LA.ID_Autor = A.ID_Autor WHERE C.ID_Compra = " + ID_Compra);

                Datos.EjecutarLectura();

                Dictionary<int, Compra> compras = new Dictionary<int, Compra>();

                while (Datos.Lector.Read())
                {
                    int idCompra = ID_Compra;
                    int idLibro = (int)Datos.Lector["ID_Libro"];
                    int cantCompra = (int)Datos.Lector["Cantidad"];

                    Compra auxCompra;
                    if (!compras.ContainsKey(idCompra))
                    {
                        auxCompra = new Compra();
                        auxCompra.Id = idCompra;
                        auxCompra.IdCliente = (int)Datos.Lector["ID_Usuario"];
                        auxCompra.FechaCompra = (DateTime)Datos.Lector["FechaCompra"];
                        auxCompra.Estado = (string)Datos.Lector["TipoEstados"];
                        auxCompra.Carrito = new Carrito();
                        auxCompra.Carrito.Libros = new List<Libro>();
                        auxCompra.Carrito.Monto = 0;

                        compras.Add(idCompra, auxCompra);
                    }
                    else
                    {
                        auxCompra = compras[idCompra];
                    }

                    for (int i = 0; i < cantCompra; i++) {
                        Libro auxLibro = new Libro();
                        auxLibro.Id = idLibro;
                        auxLibro.Codigo = (string)Datos.Lector["Codigo"];
                        auxLibro.Titulo = (string)Datos.Lector["Titulo"];
                        auxLibro.Descripcion = (string)Datos.Lector["Descripcion"];
                        auxLibro.Precio = (decimal)Datos.Lector["Precio"];

                        Autor auxAutor = new Autor();
                        auxAutor.Id = (int)Datos.Lector["ID_Autor"];
                        auxAutor.Nombre = (string)Datos.Lector["AutorNombre"];
                        auxAutor.Apellido = (string)Datos.Lector["AutorApellido"];

                        auxLibro.Autores = new List<Autor>();
                        auxLibro.Autores.Add(auxAutor);

                        if (auxCompra.Carrito != null && auxCompra.Carrito.Libros != null)
                        {
                            auxCompra.Carrito.Libros.Add(auxLibro);
                            auxCompra.Carrito.Monto += auxLibro.Precio;
                        }
                    }

                    compra =  auxCompra;
                }
                return compra;
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

        public int Agregar(Compra nuevo)
        {
            AccesoSQL datos = new AccesoSQL();
            int idCompra = -1;
            try
            {
                datos.IniciarTransaccion();

                idCompra = InsertarCompra(nuevo);

                LibroNegocio libroNegocio = new LibroNegocio();
                foreach (Libro libro in libroNegocio.RemoveDuplicadosLibro(nuevo.Carrito.Libros))
                {
                    int cantidad = nuevo.Carrito.contabilizarLibro(libro.Id);
                    InsertarLibroEnCompra(idCompra, libro.Id, cantidad);
                    libroNegocio.DescuentoStock(libro.Id, cantidad);
                }

                datos.CompletarTransaccion();
                return idCompra;
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
            LibroNegocio negocioLib = new LibroNegocio();

            try
            {
                datos.IniciarTransaccion();

                datos.Consulta("DELETE FROM Compra_X_Libro WHERE ID_Compra = " + compra.Id);
                datos.EjecutarAccion();

                foreach (Libro libro in compra.Carrito.Libros)
                {
                    int cantidad = CalcularCantidadLibros(compra.Carrito.Libros, libro.Id);
                    InsertarLibroEnCompra(compra.Id, libro.Id, cantidad);
                    negocioLib.DescuentoStock(libro.Id, cantidad);
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

        public void ModificarEstado(int ID_Estado, int ID_Compra)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {           
                datos.Consulta("UPDATE Compra SET ID_Estado = " + ID_Estado + " WHERE ID_Compra = " + ID_Compra);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
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

            datos.Consulta("INSERT INTO Compra_X_Libro (ID_Compra, ID_Libro, Cantidad) VALUES(@idCompra, @idLibro, @cantidad)");
            datos.SetParametros("idCompra", idCompra);
            datos.SetParametros("idLibro", idLibro);
            datos.SetParametros("cantidad", cantidad);
            datos.EjecutarAccion();
        }


        private int InsertarCompra(Compra nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("INSERT INTO Compra (ID_Usuario, PrecioTotal, ID_Estado) output INSERTED.ID_Compra VALUES(@idCliente, @monto , 1)");
                datos.SetParametros("idCliente", nuevo.IdCliente);
                datos.SetParametros("monto", nuevo.Carrito.Monto);
               
                int id = datos.EjecutarScalar();

                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }

        private List<Compra> groupComprasById(List<Compra> compras)
        {
             var comprasAgrupadas = compras
            .GroupBy(c => c.Id)
            .Select(group => new Compra
            {
                Id = group.Key,
                IdCliente = group.First().IdCliente,
                Estado = group.First().Estado,
                FechaCompra = group.First().FechaCompra,
                Carrito = new Carrito
                {
                    Libros = group.SelectMany(c => c.Carrito.Libros).ToList(),
                    Monto = group.First().Carrito.Monto
                },
            })
            .ToList();

            return comprasAgrupadas;
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
    
        public DataTable ReporteVentas_x_MesAnio()
        {
            DataTable dt = new DataTable();
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.setearProcedimiento("sp_VentasTotalesPorMes_Anio");
                datos.SetParametros("Anio", 2023);
                datos.SetParametros("ColumnaOrderBy", "Mes");
                datos.SetParametros("OrdenarPor", "DESC");                
                
                SqlDataAdapter adaptador = new SqlDataAdapter(datos.Comando);

                adaptador.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public DataTable ReporteVentas_x_MesAnio(int anio, String columnaOrderBy, String orderBy)
        {
            DataTable dt = new DataTable();
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.setearProcedimiento("sp_VentasTotalesPorMes_Anio");
                datos.SetParametros("Anio", anio);
                datos.SetParametros("ColumnaOrderBy", columnaOrderBy);
                datos.SetParametros("OrdenarPor", orderBy);

                SqlDataAdapter adaptador = new SqlDataAdapter(datos.Comando);

                adaptador.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }

}
