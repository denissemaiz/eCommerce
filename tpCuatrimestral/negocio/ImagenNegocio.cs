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
                Datos.Consulta("Select I.ID_Imagen, I.ID_Articulo, I.Nombre, I.ImagenURL From IMAGEN I");
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
