using Clases;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Datos.Consulta("Select C.ID, C.ID_Cliente From COMPRA C");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Compra aux = new Compra();
                    aux.Id = (int)Datos.Lector["ID"];
                    aux.IdCliente = (int)Datos.Lector["ID_Cliente"];
                    //aux.Carrito = (Carrito)Datos.Lector["Carrito"];
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
