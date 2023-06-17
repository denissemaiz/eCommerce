using Clases;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    internal class DireccionNegocio
    {
        public List<Direccion> Listar()
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select C.ID_Articulo, C.ID_Cliente From COMPRA C");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.Id = (int)Datos.Lector["ID_Articulo"];
                    aux.Calle = (string)Datos.Lector["Calle"];
                    aux.Altura = (int)Datos.Lector["Altura"];
                    aux.Localidad = (string)Datos.Lector["Localidad"];
                    aux.Cp = (int)Datos.Lector["Cp"];
                    aux.Provincia = (string)Datos.Lector["Direccion"];
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

        public List<Direccion> RemoveDuplicadosDireccion(List<Direccion> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Direccion> finalList = new List<Direccion>();
            foreach (Direccion dir in inputList)
            {
                if (!uniqueStore.ContainsKey(dir.Id.ToString()))
                {
                    uniqueStore.Add(dir.Id.ToString(), "0");
                    finalList.Add(dir);
                }
            }
            return finalList;
        }
    }
}
