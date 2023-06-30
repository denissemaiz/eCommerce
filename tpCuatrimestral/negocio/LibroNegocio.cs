using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using Clases;
using negocio;

namespace negocio
{
    public class LibroNegocio
    {
        public List<Libro> Listar() 
        {
            List<Libro> lista = new List<Libro>();
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("SELECT L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, L.Stock, L.PortadaURL FROM Libro L");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["ID_Libro"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Autores = ObtenerAutoresPorLibro(datos, aux.Id);
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)datos.Lector["Precio"], 2);
                    aux.Stock = (Int16)datos.Lector["Stock"];
                    aux.Generos = ObtenerGenerosPorLibro(datos, aux.Id);
                    aux.PortadaURL = (string)datos.Lector["PortadaURL"];
                    lista.Add(aux);
                }
                    return lista;
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

        public List<Libro> ListarL()
        {
            List<Libro> lista = new List<Libro>();
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("SELECT L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, L.Stock, L.PortadaURL FROM Libro L");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["ID_Libro"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)datos.Lector["Precio"], 2);
                    aux.Stock = (Int16)datos.Lector["Stock"];
                    aux.PortadaURL = (string)datos.Lector["PortadaURL"];
                    lista.Add(aux);
                }
                return lista;
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

        public List<Libro> PruebaBuscar(string Id = "")
        {
            List<Libro> lista = new List<Libro>();
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("SELECT L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, L.Stock, L.PortadaURL FROM Libro L where L.ID_Libro =" + Id);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["ID_Libro"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)datos.Lector["Precio"], 2);
                    aux.Stock = (Int16)datos.Lector["Stock"];
                    aux.PortadaURL = (string)datos.Lector["PortadaURL"];
                    lista.Add(aux);
                }
                return lista;
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


        private List<Autor> ObtenerAutoresPorLibro(AccesoSQL datos, int idLibro)
        {
            List<Autor> autores = new List<Autor>();

            datos.Consulta("SELECT A.ID_Autor, A.Nombre, A.Apellido " +
                           "FROM Libro_X_Autor LA " +
                           "INNER JOIN Autor A ON LA.ID_Autor = A.ID_Autor " +
                           "WHERE LA.ID_Libro = " + idLibro);
            datos.EjecutarLectura();

            while (datos.Lector.Read())
            {
                Autor autor = new Autor();
                autor.Id = (int)datos.Lector["ID_Autor"];
                autor.Nombre = (string)datos.Lector["Nombre"];
                autor.Apellido = (string)datos.Lector["Apellido"];
                autores.Add(autor);
            }

            return autores;
        }

        private List<Genero> ObtenerGenerosPorLibro(AccesoSQL datos, int idLibro)
        {
            List<Genero> generos = new List<Genero>();

            datos.Consulta("SELECT G.ID_Genero, G.Nombre, G.Descripcion " +
                           "FROM Genero_X_Libro GL " +
                           "INNER JOIN Genero G ON GL.ID_Genero = G.ID_Genero " +
                           "WHERE GL.ID_Libro = " + idLibro);
            datos.EjecutarLectura();

            while (datos.Lector.Read())
            {
                Genero genero = new Genero();
                genero.Id = (int)datos.Lector["ID_Genero"];
                genero.Nombre = (string)datos.Lector["Nombre"];
                genero.Descripcion = (string)datos.Lector["Descripcion"];
                generos.Add(genero);
            }

            return generos;
        }

        public void Agregar(Libro nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("INSERT INTO Libro (Codigo, Titulo, Descripcion, Precio, Stock, PortadaURL) " +
                              "VALUES ('" + nuevo.Codigo + "', '" + nuevo.Titulo + "', '" + nuevo.Descripcion + "', '" + nuevo.Precio + "', '" + nuevo.Stock + "', " +
                              "'" + nuevo.PortadaURL +"')");
                datos.EjecutarAccion();

                int idLibro = ObtenerUltimoIdInsertado(datos);

                foreach (Autor autor in nuevo.Autores)
                {
                    datos.Consulta("INSERT INTO Libro_X_Autor (ID_Libro, ID_Autor) " +
                                  "VALUES (" + idLibro + ", " + autor.Id + ")");
                    datos.EjecutarAccion();
                }

                foreach (Genero genero in nuevo.Generos)
                {
                    datos.Consulta("INSERT INTO Genero_X_Libro (ID_Genero, ID_Libro) " +
                                  "VALUES (" + genero.Id + ", " + idLibro + ")");
                    datos.EjecutarAccion();
                }
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
       
        private int ObtenerUltimoIdInsertado(AccesoSQL datos)
        {
            datos.Consulta("SELECT SCOPE_IDENTITY() AS ID");
            datos.EjecutarLectura();

            int id = 0;

            if (datos.Lector.Read())
            {
                id = Convert.ToInt32(datos.Lector["ID"]);
            }

            datos.Lector.Close();
            return id;
        }

        public void Eliminar(int Id)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("DELETE FROM Libro_X_Autor WHERE ID_Libro = " + Id);
                datos.EjecutarAccion();

                datos.Consulta("DELETE FROM Libro WHERE ID_Libro = " + Id);
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






        public void ModificarTest(Libro libro)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("UPDATE Libro SET Codigo = '" + libro.Codigo + "', Titulo = '" + libro.Titulo + "', Descripcion = '" + libro.Descripcion + "', Precio = " +
                    "'" + nuevo.Precio + "', Stock = " + libro.Stock + "', PortadaURL = '" + libro.PortadaURL + "' WHERE ID_Libro = " + libro.Id);
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






        public void Modificar(Libro libro)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("UPDATE Libro SET Codigo = '" + libro.Codigo + "', Titulo = '" + libro.Titulo + "', Descripcion = '" + libro.Descripcion + "', Precio = " +
                    "" + libro.Precio + ", Stock = " + libro.Stock + ", PortadaURL = '" + libro.PortadaURL + "' WHERE ID_Libro = " + libro.Id);
                datos.EjecutarAccion();

                datos.Consulta("DELETE FROM Libro_X_Autor WHERE ID_Libro = " + libro.Id);
                datos.EjecutarAccion();

                foreach (Autor autor in libro.Autores)
                {
                    datos.Consulta("INSERT INTO Libro_X_Autor (ID_Libro, ID_Autor) " +
                                  "VALUES (" + libro.Id + ", " + autor.Id + ")");
                    datos.EjecutarAccion();
                }

                datos.Consulta("DELETE FROM Genero_X_Libro WHERE ID_Libro = " + libro.Id);
                datos.EjecutarAccion();

                foreach (Genero genero in libro.Generos)
                {
                    datos.Consulta("INSERT INTO Genero_X_Libro (ID_Genero, ID_Libro) " +
                                  "VALUES (" + genero.Id + ", " + libro.Id + ")");
                    datos.EjecutarAccion();
                }
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

        public List<Libro> RemoveDuplicadosLibro(List<Libro> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Libro> finalList = new List<Libro>();
            foreach (Libro lib in inputList)
            {
                if (!uniqueStore.ContainsKey(lib.Codigo.ToString()))
                {
                    uniqueStore.Add(lib.Codigo.ToString(), "0");
                    finalList.Add(lib);
                }
            }
            return finalList;
        }
    }
}
