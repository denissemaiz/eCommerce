using Clases;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    internal class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoSQL Datos = new AccesoSQL();

            try
            {
                Datos.Consulta("Select U.Id, U.Nombre, U.Mail, U.Contraseña From USUARIO U");
                Datos.EjecutarLectura();

                while (Datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)Datos.Lector["Id"];
                    aux.Username = (string)Datos.Lector["Nombre"];
                    aux.Mail = (string)Datos.Lector["Mail"];
                    aux.Contraseña = (string)Datos.Lector["Contraseña"];
                    //aux.DatosUsuario = (DatosUsuario)Datos.Lector[""];                   
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

        public List<Usuario> RemoveDuplicadosUsuario(List<Usuario> inputList)
        {
            Dictionary<string, string> uniqueStore = new Dictionary<string, string>();
            List<Usuario> finalList = new List<Usuario>();
            foreach (Usuario us in inputList)
            {
                if (!uniqueStore.ContainsKey(us.Id.ToString()))
                {
                    uniqueStore.Add(us.Id.ToString(), "0");
                    finalList.Add(us);
                }
            }
            return finalList;
        }
    }
}
