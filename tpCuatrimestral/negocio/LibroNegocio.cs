using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using Clases;
using negocio;
using Conexiones;
using System.Linq.Expressions;
using System.Globalization;

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
                datos.Consulta("SELECT L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, L.Stock, L.PortadaURL, A.ID_Autor, A.Nombre AS AutorNombre, A.Apellido AS AutorApellido, G.ID_Genero, G.Nombre AS GeneroNombre, G.Descripcion AS GeneroDescripcion " +
                               "FROM Libro L " +
                               "LEFT JOIN Libro_X_Autor LA ON L.ID_Libro = LA.ID_Libro " +
                               "LEFT JOIN Autor A ON LA.ID_Autor = A.ID_Autor " +
                               "LEFT JOIN Genero_X_Libro GL ON L.ID_Libro = GL.ID_Libro " +
                               "LEFT JOIN Genero G ON GL.ID_Genero = G.ID_Genero");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    int idLibro = (int)datos.Lector["ID_Libro"];
                    Libro aux = lista.FirstOrDefault(l => l.Id == idLibro);

                    if (aux == null)
                    {
                        aux = new Libro();
                        aux.Id = idLibro;
                        aux.Codigo = (string)datos.Lector["Codigo"];
                        aux.Titulo = (string)datos.Lector["Titulo"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Precio = Decimal.Round((decimal)datos.Lector["Precio"], 2);
                        aux.Stock = (Int32)datos.Lector["Stock"];
                        aux.PortadaURL = (string)datos.Lector["PortadaURL"];
                        aux.Autores = new List<Autor>();
                        aux.Generos = new List<Genero>();

                        lista.Add(aux);
                    }

                    int idAutor = (int)datos.Lector["ID_Autor"];
                    string autorNombre = (string)datos.Lector["AutorNombre"];
                    string autorApellido = (string)datos.Lector["AutorApellido"];

                    if (idAutor != 0 && !string.IsNullOrEmpty(autorNombre))
                    {
                        Autor autor = new Autor();
                        autor.Id = idAutor;
                        autor.Nombre = autorNombre;
                        autor.Apellido = autorApellido;
                        aux.Autores.Add(autor);
                    }

                    int idGenero = (int)datos.Lector["ID_Genero"];
                    string generoNombre = (string)datos.Lector["GeneroNombre"];
                    string generoDescripcion = (string)datos.Lector["GeneroDescripcion"];

                    if (idGenero != 0 && !string.IsNullOrEmpty(generoNombre))
                    {
                        Genero genero = new Genero();
                        genero.Id = idGenero;
                        genero.Nombre = generoNombre;
                        genero.Descripcion = generoDescripcion;
                        aux.Generos.Add(genero);
                    }
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

        public List<Libro> Buscar(string busqueda, string criterio)
        {
            List<Libro> lista = new List<Libro>();
            AccesoSQL datos = new AccesoSQL();

            try
            {
                criterio = ManejoDeCriterio(criterio);

                datos.Consulta("SELECT L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, L.Stock, L.PortadaURL, " +
                    "A.ID_Autor, A.Nombre AS AutorNombre, A.Apellido AS AutorApellido, " +
                    "G.ID_Genero, G.Nombre AS GeneroNombre, G.Descripcion AS GeneroDescripcion " +
                    "FROM Libro L LEFT JOIN Libro_X_Autor LA ON L.ID_Libro = LA.ID_Libro " +
                    "LEFT JOIN Autor A ON LA.ID_Autor = A.ID_Autor " +
                    "LEFT JOIN Genero_X_Libro GL ON L.ID_Libro = GL.ID_Libro " +
                    "LEFT JOIN Genero G ON GL.ID_Genero = G.ID_Genero " +
                    "WHERE " + criterio + " LIKE '%" + busqueda + "%'");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    int idLibro = (int)datos.Lector["ID_Libro"];
                    Libro aux = lista.FirstOrDefault(l => l.Id == idLibro);

                    if (aux == null)
                    {
                        aux = new Libro();
                        aux.Id = idLibro;
                        aux.Codigo = (string)datos.Lector["Codigo"];
                        aux.Titulo = (string)datos.Lector["Titulo"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Precio = Decimal.Round((decimal)datos.Lector["Precio"], 2);
                        aux.Stock = (Int16)datos.Lector["Stock"];
                        aux.PortadaURL = (string)datos.Lector["PortadaURL"];
                        aux.Autores = new List<Autor>();
                        aux.Generos = new List<Genero>();

                        lista.Add(aux);
                    }

                    int idAutor = (int)datos.Lector["ID_Autor"];
                    string autorNombre = (string)datos.Lector["AutorNombre"];
                    string autorApellido = (string)datos.Lector["AutorApellido"];

                    if (idAutor != 0 && !string.IsNullOrEmpty(autorNombre))
                    {
                        Autor autor = new Autor();
                        autor.Id = idAutor;
                        autor.Nombre = autorNombre;
                        autor.Apellido = autorApellido;
                        aux.Autores.Add(autor);
                    }

                    int idGenero = (int)datos.Lector["ID_Genero"];
                    string generoNombre = (string)datos.Lector["GeneroNombre"];
                    string generoDescripcion = (string)datos.Lector["GeneroDescripcion"];

                    if (idGenero != 0 && !string.IsNullOrEmpty(generoNombre))
                    {
                        Genero genero = new Genero();
                        genero.Id = idGenero;
                        genero.Nombre = generoNombre;
                        genero.Descripcion = generoDescripcion;
                        aux.Generos.Add(genero);
                    }
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

        public Libro Buscar_X_Id(string id)
        {
            Libro buscado = new Libro();
            AccesoSQL datos = null;
            try
            {
                datos = new AccesoSQL();
                //Seteo la consulta
                datos.Consulta("Select * From Libro WHERE ID_Libro = @ID_Libro");
                datos.SetParametros("ID_Libro", id);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                     
                    buscado.Id = (Int32)datos.Lector["ID_Libro"];
                    buscado.Codigo = (String)datos.Lector["Codigo"];
                    buscado.Titulo = (String)datos.Lector["Titulo"];
                    buscado.Descripcion = (String)datos.Lector["Descripcion"];
                    buscado.Precio = Decimal.Round((decimal)datos.Lector["Precio"], 2);
                    buscado.Stock = (Int16)datos.Lector["Stock"];
                    buscado.PortadaURL = (String)datos.Lector["PortadaURL"];
                }
                
                GeneroNegocio generoNegocio = new GeneroNegocio();
                buscado.Generos = generoNegocio.BuscarGenero(buscado.Codigo);//Busco todos los generos del libro encontrado

                AutorNegocio autorNegocio = new AutorNegocio();
                buscado.Autores = autorNegocio.BuscarAutor(buscado.Codigo);//Busco todos los autores del libro encontrado
                
                return buscado;
            }
            catch (Exception ex)
            {
                return buscado = null; //En caso de error devuelvo el libro como NULL para realizar validaciones
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public Libro Buscar_x_Codigo(String codigo)
        {
            Libro buscado = new Libro();
            AccesoSQL datos = null;
            try
            {
                datos = new AccesoSQL();
                //Seteo la consulta
                datos.Consulta("Select * From Libro WHERE Codigo = @Codigo");
                datos.SetParametros("Codigo", codigo);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {

                    buscado.Id = (Int32)datos.Lector["ID_Libro"];
                    buscado.Codigo = (String)datos.Lector["Codigo"];
                    buscado.Titulo = (String)datos.Lector["Titulo"];
                    buscado.Descripcion = (String)datos.Lector["Descripcion"];
                    buscado.Precio = Decimal.Round((decimal)datos.Lector["Precio"], 2);
                    buscado.Stock = (Int16)datos.Lector["Stock"];
                    buscado.PortadaURL = (String)datos.Lector["PortadaURL"];
                }

                GeneroNegocio generoNegocio = new GeneroNegocio();
                buscado.Generos = generoNegocio.BuscarGenero(buscado.Codigo);//Busco todos los generos del libro encontrado

                AutorNegocio autorNegocio = new AutorNegocio();
                buscado.Autores = autorNegocio.BuscarAutor(buscado.Codigo);//Busco todos los autores del libro encontrado

                return buscado;
            }
            catch (Exception ex)
            {
                return buscado = null; //En caso de error devuelvo el libro como NULL para realizar validaciones
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

       



        private string ManejoDeCriterio(string criterio)
        {
            if (criterio == "ID_Genero" || criterio == "Genero")
                return "G." + criterio;
            if (criterio == "ID_Autor" || criterio == "Apellido" || criterio == "Nombre")
                return "A." + criterio;
            if (criterio == "ID_Libro" || criterio == "Codigo" || criterio == "Titulo")
                return "L." + criterio;
            //agregar criterios necesarios
            return criterio;
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


        public List<Libro> BuscarporCodigo(string codigo)
        {
            List<Libro> lista = new List<Libro>();
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta(" SELECT L.ID_Libro, L.Codigo, L.Titulo, L.Descripcion, L.Precio, L.Stock, L.PortadaURL FROM Libro L WHERE L.Codigo = '" + codigo + "' ");
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

        public void Agregar(Libro nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("INSERT INTO Libro (Codigo, Titulo, Descripcion, Precio, Stock, PortadaURL) " +
                              "VALUES ('" + nuevo.Codigo + "', '" + nuevo.Titulo + "', '" + nuevo.Descripcion + "', '" + nuevo.Precio + "', '" + nuevo.Stock + "', " +
                              "'" + nuevo.PortadaURL +"')");
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                datos.RevertirTransaccion(); //En caso de error se revierte el insert
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            int idLibro = ObtenerUltimoIdInsertado(datos, nuevo.Codigo); //Se obtiene el ID del libro insertado

            try
            { 
                AutorNegocio autorNegocio = new AutorNegocio();
                foreach (Autor autor in nuevo.Autores)
                {
                    //Por cada Autor en el listado del libro agrego un registro a Libro_X_Autor con la funcion de Agregar_a_Libro
                    autorNegocio.Agregar_a_Libro(autor.Id, idLibro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                GeneroNegocio generoNegocio = new GeneroNegocio();
                foreach (Genero genero in nuevo.Generos)
                {
                    //Por cada Genero en el listado del libro agrego un registro a Genero_X_Libro con la funcion de Agregar_a_Libro
                    generoNegocio.Agregar_a_Libro(genero.Id, idLibro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private int ObtenerUltimoIdInsertado(AccesoSQL datos, string codigo)
        {
            datos.Consulta("SELECT L.ID_Libro FROM LIBRO L WHERE CODIGO = '" + codigo + "'");
            datos.EjecutarLectura();

            int id = 0;

            if (datos.Lector.Read())
            {
                id = Convert.ToInt32(datos.Lector["ID_Libro"]);
            }

            datos.CerrarConexion();

            return id;
        }

        public void Eliminar(int Id)
        {
            AccesoSQL datos = new AccesoSQL();
            try
            {
                datos.Consulta("DELETE FROM Libro_X_Autor WHERE ID_Libro = " + Id);
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
            try
            {
                datos.Consulta("DELETE FROM Genero_X_Libro WHERE ID_Libro = " + Id);
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
            try
            {
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

        public void Modificar(Libro libro)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("UPDATE Libro SET Codigo =  '" + libro.Codigo + "', Titulo = '" + libro.Titulo + "', Descripcion = '" + libro.Descripcion + "', Precio = '" + libro.Precio.ToString("F", CultureInfo.InvariantCulture) + "', Stock = '" + libro.Stock + "', PortadaURL = '" + libro.PortadaURL + "' WHERE ID_Libro = " + libro.Id);

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
            try
            {
                AutorNegocio autorNegocio = new AutorNegocio();
                autorNegocio.LimpiarAutoresLibro(libro.Id); //Limpio todos los registros del libro en Libro_X_Autor
                foreach (Autor autor in libro.Autores) //Luego regenero los registros por cada autor en el libro
                {
                    autorNegocio.Agregar_a_Libro(autor.Id, libro.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                GeneroNegocio generoNegocio = new GeneroNegocio();
                generoNegocio.LimpiarGenerosLibro(libro.Id); //Limpio todos los registros del libro en Genero_X_Libro
                foreach (Genero genero in libro.Generos) //Luego regenero los registros por cada Genero en el listado del libro actual
                {
                    generoNegocio.Agregar_a_Libro(genero.Id, libro.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        public void DescuentoStock(int idLibro, int cantidadComprada)
        {
            AccesoSQL datos = new AccesoSQL();

            datos.Consulta("UPDATE Libro SET Stock = Stock - " + cantidadComprada + " WHERE ID_Libro = " + idLibro);
            datos.EjecutarAccion();
        }

        public void SumarStock(Compra compra)
        {
            AccesoSQL datos = new AccesoSQL();
            Dictionary<int, int> libroCantidadMap = new Dictionary<int, int>();


            foreach (Libro lib in compra.Carrito.Libros)
            {
                int cant = CalcularCantidadLibros(compra.Carrito.Libros, lib.Id);
                libroCantidadMap[lib.Id] = cant;
            }

            foreach (var key in libroCantidadMap)
            {

                datos.Consulta("UPDATE Libro SET Stock = Stock + " + key.Value + " WHERE ID_Libro = " + key.Key);
                datos.EjecutarAccion();
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
    }
}
