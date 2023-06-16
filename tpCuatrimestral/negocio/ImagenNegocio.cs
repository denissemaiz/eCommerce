using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> Listar()
        {
            List<Imagen> Listar = new List<Imagen>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select Id, IdArticulo, ImagenUrl, ImagenNombre as Imagen From IMAGENES");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.IdArticulo = (int)Datos.Lector["IdArticulo"];
                    aux.Nombre = (string)Datos.Lector["ImagenNombre"];
                    aux.Url = (string)Datos.Lector["Imagen"];
                    Listar.Add(aux);
                }
                return Listar;
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

        public void Agregar(Imagen nuevo)
        {
            AccesoSQL datos = new AccesoSQL();

            try
            {
                datos.Consulta("Insert into IMAGENES (IdArticulo, ImagenUrl, ImagenNombre) VALUES('" + nuevo.IdArticulo + "', '" + nuevo.Nombre + "', '" + nuevo.Url + "')");
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

        public List<Imagen> Buscar(string TipoBusqueda, string Valor)
        {
            List<Imagen> busqueda = new List<Imagen>();
            AccesoSQL Datos = new AccesoSQL();
            try
            {
                Datos.Consulta("Select Id, IdArticulo, ImagenUrl, ImagenNombre From IMAGENES Where " + TipoBusqueda + " LIKE '" + Valor + "'");
                Datos.EjecutarLectura();
                
                bool encontro = false;
                while (Datos.Lector.Read())
                {
                    encontro = true;
                    Imagen aux = new Imagen();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.IdArticulo = (int)Datos.Lector["IdArticulo"];
                    aux.Nombre = (string)Datos.Lector["ImagenNombre"];
                    aux.Url = (string)Datos.Lector["ImagenUrl"];

                    busqueda.Add(aux);
                }
                if (encontro)
                    return busqueda;
                else
                    return null;
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

        public void Eliminar(int Id)
        {
            try
            {
                AccesoSQL datos = new AccesoSQL();
                datos.Consulta("DELETE from IMAGENES where Id = @Id");
                datos.SetParametros("@Id", Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Imagen> RemoveDuplicadosImagen(List<Imagen> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Imagen> finalList = new List<Imagen>();
            foreach (Imagen img in inputList)
            {
                if (!uniqueStore.ContainsKey(img.Url))
                {
                    uniqueStore.Add(img.Url, "0");
                    finalList.Add(img);
                }
            }
            return finalList;
        }
    }
}
