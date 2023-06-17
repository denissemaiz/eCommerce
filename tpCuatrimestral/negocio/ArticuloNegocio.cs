using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar() 
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select A.ID_Articulo, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.Stock, A.ID_Categoria From ARTICULO A");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)Datos.Lector["ID_Articulo"];
                    aux.Codigo = (Int16)Datos.Lector["Codigo"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Descripcion = (string)Datos.Lector["Descripcion"];
                    aux.Precio = Decimal.Round((decimal)Datos.Lector["Precio"], 2);
                    aux.Stock = (Int16)Datos.Lector["Stock"];
                    aux.IdCategoria = (int)Datos.Lector["ID_Categoria"];
                    //aux.IdImagen = (List<Imagen>)Datos.Lector["Imagen"];
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
                Datos.CerrarConexion();
            }                               
        }

        public List<Articulo> RemoveDuplicadosArticulo(List<Articulo> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Articulo> finalList = new List<Articulo>();
            foreach (Articulo art in inputList)
            {
                if (!uniqueStore.ContainsKey(art.Codigo.ToString()))
                {
                    uniqueStore.Add(art.Codigo.ToString(), "0");
                    finalList.Add(art);
                }
            }
            return finalList;
        }
    }
}
